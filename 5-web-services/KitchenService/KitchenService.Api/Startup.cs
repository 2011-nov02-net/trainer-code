using KitchenService.Api.Formatters;
using KitchenService.Api.Model;
using KitchenService.Api.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace KitchenService.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<Fridge>();
            services.AddSingleton<INoteRepository, NoteRepository>();

            services.AddControllers(options =>
            {
                // make asp.net core forget about text/plain so swagger ui uses json as the default
                options.OutputFormatters.RemoveType<StringOutputFormatter>();
                // teach asp.net core to be able to serialize & deserialize XML
                options.InputFormatters.Add(new XmlSerializerInputFormatter(options));
                options.OutputFormatters.Add(new XmlSerializerOutputFormatter());
                options.InputFormatters.Add(new FredInputFormatter());
                options.OutputFormatters.Add(new FredOutputFormatter());

                options.ReturnHttpNotAcceptable = true;
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "KitchenService.Api", Version = "v1" });
            });
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200")
                            .AllowAnyMethod() // allow PUT & DELETE not just GET & POST
                            .AllowAnyHeader()
                            .AllowCredentials(); // auth tokens, login/password, etc. coming in headers are treated specially
                    });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "KitchenService.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
