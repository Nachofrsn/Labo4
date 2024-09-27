﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using concesionarioAPI.Config;

#nullable disable

namespace concesionarioAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240823174045_DbModelAutoReferencesCombustible")]
    partial class DbModelAutoReferencesCombustible
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("concesionarioAPI.Models.Auto.Auto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CantidadPuertas")
                        .HasColumnType("int");

                    b.Property<int>("CombustibleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaFabricacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("TieneEstereo")
                        .HasColumnType("bit");

                    b.Property<string>("Transmision")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("CombustibleId");

                    b.ToTable("Autos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CantidadPuertas = 4,
                            CombustibleId = 1,
                            FechaFabricacion = new DateTime(2020, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Marca = "Toyota",
                            Modelo = "Corolla",
                            TieneEstereo = true,
                            Transmision = "Automática"
                        },
                        new
                        {
                            Id = 2,
                            CantidadPuertas = 4,
                            CombustibleId = 1,
                            FechaFabricacion = new DateTime(2019, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Marca = "Honda",
                            Modelo = "Civic",
                            TieneEstereo = true,
                            Transmision = "Manual"
                        },
                        new
                        {
                            Id = 3,
                            CantidadPuertas = 4,
                            CombustibleId = 2,
                            FechaFabricacion = new DateTime(2021, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Marca = "Ford",
                            Modelo = "Focus",
                            TieneEstereo = false,
                            Transmision = "Automática"
                        },
                        new
                        {
                            Id = 4,
                            CantidadPuertas = 4,
                            CombustibleId = 1,
                            FechaFabricacion = new DateTime(2022, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Marca = "Chevrolet",
                            Modelo = "Cruze",
                            TieneEstereo = true,
                            Transmision = "Automática"
                        },
                        new
                        {
                            Id = 5,
                            CantidadPuertas = 4,
                            CombustibleId = 1,
                            FechaFabricacion = new DateTime(2018, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Marca = "Volkswagen",
                            Modelo = "Golf",
                            TieneEstereo = false,
                            Transmision = "Manual"
                        });
                });

            modelBuilder.Entity("concesionarioAPI.Models.Combustible.Combustible", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Combustibles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nombre = "Gasolina"
                        },
                        new
                        {
                            Id = 2,
                            Nombre = "Diesel"
                        },
                        new
                        {
                            Id = 3,
                            Nombre = "Gas"
                        },
                        new
                        {
                            Id = 4,
                            Nombre = "Electricidad"
                        });
                });

            modelBuilder.Entity("concesionarioAPI.Models.Auto.Auto", b =>
                {
                    b.HasOne("concesionarioAPI.Models.Combustible.Combustible", "Combustible")
                        .WithMany()
                        .HasForeignKey("CombustibleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Combustible");
                });
#pragma warning restore 612, 618
        }
    }
}