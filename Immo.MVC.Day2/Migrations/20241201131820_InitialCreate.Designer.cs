﻿// <auto-generated />
using System;
using Immo.MVC.Day2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Immo.MVC.Day2.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241201131820_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.36")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Immo.MVC.Day2.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryName = "Electronics"
                        },
                        new
                        {
                            Id = 2,
                            CategoryName = "Mobiles"
                        },
                        new
                        {
                            Id = 3,
                            CategoryName = "Computer"
                        },
                        new
                        {
                            Id = 4,
                            CategoryName = "Home Needs"
                        });
                });

            modelBuilder.Entity("Immo.MVC.Day2.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<decimal?>("Price")
                        .IsRequired()
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Quantity")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddedDate = new DateTime(2024, 12, 1, 18, 48, 20, 598, DateTimeKind.Local).AddTicks(4644),
                            CategoryId = 3,
                            Price = 50000.5m,
                            ProductName = "HP Laptop",
                            Quantity = 100
                        },
                        new
                        {
                            Id = 2,
                            AddedDate = new DateTime(2024, 12, 1, 18, 48, 20, 598, DateTimeKind.Local).AddTicks(4661),
                            CategoryId = 4,
                            Price = 850m,
                            ProductName = "Water Bottle",
                            Quantity = 252
                        },
                        new
                        {
                            Id = 3,
                            AddedDate = new DateTime(2024, 12, 1, 18, 48, 20, 598, DateTimeKind.Local).AddTicks(4871),
                            CategoryId = 2,
                            Price = 37599.99m,
                            ProductName = "Apple Watch 7",
                            Quantity = 15
                        },
                        new
                        {
                            Id = 4,
                            AddedDate = new DateTime(2024, 12, 1, 18, 48, 20, 598, DateTimeKind.Local).AddTicks(4872),
                            CategoryId = 2,
                            Price = 109999.99m,
                            ProductName = "iPhone 16 Pro",
                            Quantity = 50
                        });
                });

            modelBuilder.Entity("Immo.MVC.Day2.Models.Product", b =>
                {
                    b.HasOne("Immo.MVC.Day2.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}