﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimpleOrderApp.Data.Model;

namespace SimpleOrderApp.Data.Migrations
{
    [DbContext(typeof(SimpleOrderContext))]
    partial class SimpleOrderContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5");

            modelBuilder.Entity("SimpleOrderApp.Data.Model.LocationEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Stock")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Locations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "cookie shop 1",
                            Stock = 100
                        },
                        new
                        {
                            Id = 2,
                            Name = "cookie shop 2",
                            Stock = 2
                        });
                });

            modelBuilder.Entity("SimpleOrderApp.Data.Model.OrderEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("LocationId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("SimpleOrderApp.Data.Model.OrderEntity", b =>
                {
                    b.HasOne("SimpleOrderApp.Data.Model.LocationEntity", "Location")
                        .WithMany("Orders")
                        .HasForeignKey("LocationId");
                });
#pragma warning restore 612, 618
        }
    }
}
