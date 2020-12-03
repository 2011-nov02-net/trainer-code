using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleOrderApp.Data;
using SimpleOrderApp.Data.Model;
using SimpleOrderApp.Domain;
using SimpleOrderApp.WebApp.Filters;
using SimpleOrderApp.WebApp.Services;

namespace SimpleOrderApp.WebApp
{
    public class Startup
    {
        // this configuration object gets constructed from multiple sources of key-value pairs

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // teach ASP.NET Core about the dbcontext (so one can be created for each thing that needs it)
            services.AddDbContext<SimpleOrderContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("Sqlite")));
            // AddDbContext makes it "scoped" by default.
            // it shouldn't be singleton because it's not threadsafe, also it's meant to be short-lived
            // it COULD be transient.

            // ^ if you get a NullReferenceException there, it's because you need to put this in
            // user secrets:
            //"ConnectionStrings": {
            //    "Sqlite": "Data Source=C:/revature/simpleorder.db"
            //}

            // "if anyone asks for an ILocationRepository, construct a LocationRepository"
            services.AddScoped<ILocationRepository, LocationRepository>();

            // flexible... e.g.:
            //if (Configuration["WhichRepository"] == "1")
            //{
            //    services.AddScoped<ILocationRepository, LocationRepository>();
            //}
            //else
            //{
            //    //services.AddScoped<ILocationRepository, LocationRepositoryOther>();
            //}

            var loc = new Location("asdf", 123);
            services.AddSingleton(loc); // can do it this way for singletons
            // can do it this way for anything
            services.AddSingleton(sp => new Location("asdf", 123));
            // that "sp" parameter is a service provider - you can get other services from it
            // you could write it this way... but it does that by default anyway:
            //services.AddSingleton(sp => new LocationRepository(sp.GetService<SimpleOrderContext>()));

            //services.AddScoped<LocationRepository>();
            // (equivalent to:)
            //services.AddScoped<LocationRepository>(sp => new LocationRepository(sp.GetService<SimpleOrderContext>()));

            // three service lifetimes:
            // - singleton: one instance for the whole app lifetime
            // - scoped: one instance per HTTP request cycle, shared by anything within that one request's scope
            //      (default for the dbcontext)
            // - transient: a new instance for every time a different object needs one

            // better to define an interface for this
            services.AddSingleton<VisitCounter>();

            services.AddControllersWithViews(options =>
            {
                options.Filters.Add<VisitCountingFilterAttribute>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute(
                //    name: "create-location",
                //    pattern: "new-location/{email}",
                //    defaults: new { controller = "Location", action = "Create" });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
