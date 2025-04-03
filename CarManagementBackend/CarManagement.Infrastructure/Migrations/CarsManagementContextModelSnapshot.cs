﻿// <auto-generated />
using System;
using CarManagement.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarManagement.Infrastructure.Migrations
{
    [DbContext(typeof(CarsManagementContext))]
    partial class CarsManagementContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CarManagement.Domain.Car", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("IsElectric")
                        .HasColumnType("bit");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<long>("Year")
                        .HasMaxLength(255)
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e688880b-fe34-4362-8786-e4464744bf87"),
                            Color = "Red",
                            IsElectric = false,
                            Manufacturer = "Toyota",
                            ModelName = "Corolla",
                            Year = 2020L
                        },
                        new
                        {
                            Id = new Guid("e688880b-fe34-4362-8786-e4464744bf88"),
                            Color = "Blue",
                            IsElectric = false,
                            Manufacturer = "Honda",
                            ModelName = "Civic",
                            Year = 2019L
                        },
                        new
                        {
                            Id = new Guid("e688880b-fe34-4362-8786-e4464744bf89"),
                            Color = "Black",
                            IsElectric = false,
                            Manufacturer = "Ford",
                            ModelName = "Mustang",
                            Year = 2021L
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
