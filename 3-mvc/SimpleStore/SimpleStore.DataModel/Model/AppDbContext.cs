using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace SimpleStore.DataModel.Model
{
    public class AppDbContext : DbContext
    {
        // constructors
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

        // dbsets for my tables
        // (if there's some dbset you won't use directly, you can leave it out here)
        public DbSet<Location> Locations { get; set; }
        public DbSet<Order> Orders { get; set; }

        // onmodelcreating override
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(80);

                entity.HasCheckConstraint(
                    name: "CK_Location_Stock_Nonnegative",
                    sql: "[Stock] >= 0");
            });


            modelBuilder.Entity<Order>(entity =>
            {
                // configure the relationship with fluent API
                entity.HasOne(o => o.Location)
                    .WithMany(l => l.Orders)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
                //.HasForeignKey(o => o.LocationId);

                // if you do not put a property representing the FK column
                // in you model yourself, EF will make a "shadow property" for it anyway

                entity.HasCheckConstraint(
                    name: "CK_Order_Quantity_Nonnegative",
                    sql: "[Quantity] >= 0");
            });
            //new Guid("5e3a0865-04ec-4750-9e0b-f260975c6746")
            // new Guid("96ecb795-a9f6-47af-bf7f-675a5778505a")

            modelBuilder.Entity<Location>().HasData(
                new Location { Id = 1, Name = "Mcdonalds", Stock = 20 },
                new Location { Id = 2, Name = "Burger King", Stock = 10 });

            modelBuilder.Entity<Order>().HasData(
                new { Id = new Guid("5e3a0865-04ec-4750-9e0b-f260975c6746"), LocationId = 1, Quantity = 2 } );
        }
    }
}
