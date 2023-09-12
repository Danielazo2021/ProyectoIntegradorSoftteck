﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoIntegradorSoftteck.DataAccess;

#nullable disable

namespace ProyectoIntegradorSoftteck.Migrations
{
    [DbContext(typeof(ContextDB))]
    partial class ContextDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ProyectoIntegradorSoftteck.Entities.Proyecto", b =>
                {
                    b.Property<int>("CodProyecto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodProyecto"), 1L, 1);

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodProyecto");

                    b.ToTable("proyectos");

                    b.HasData(
                        new
                        {
                            CodProyecto = 11,
                            Direccion = "Libertad 180 Carloz Paz",
                            Estado = 2,
                            Nombre = "Renovacion estudio Gomez"
                        },
                        new
                        {
                            CodProyecto = 12,
                            Direccion = "Av San Martin S/N Rio Cuarto",
                            Estado = 1,
                            Nombre = "Ampliacion Anfiteatro RC"
                        },
                        new
                        {
                            CodProyecto = 13,
                            Direccion = "Colon 1050 Cordoba Capital",
                            Estado = 3,
                            Nombre = "Renovacion Teatro Colon"
                        });
                });

            modelBuilder.Entity("ProyectoIntegradorSoftteck.Entities.Servicio", b =>
                {
                    b.Property<int>("CodServicio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodServicio"), 1L, 1);

                    b.Property<string>("Descr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<double>("ValorHora")
                        .HasColumnType("float");

                    b.HasKey("CodServicio");

                    b.ToTable("servicios");

                    b.HasData(
                        new
                        {
                            CodServicio = 11,
                            Descr = "Electricidad",
                            Estado = true,
                            ValorHora = 1500.0
                        },
                        new
                        {
                            CodServicio = 12,
                            Descr = "Plomeria",
                            Estado = true,
                            ValorHora = 750.0
                        },
                        new
                        {
                            CodServicio = 13,
                            Descr = "Carpintería",
                            Estado = true,
                            ValorHora = 900.0
                        },
                        new
                        {
                            CodServicio = 14,
                            Descr = "Jardineria",
                            Estado = false,
                            ValorHora = 900.0
                        });
                });

            modelBuilder.Entity("ProyectoIntegradorSoftteck.Entities.Trabajo", b =>
                {
                    b.Property<int>("CodTrabajo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodTrabajo"), 1L, 1);

                    b.Property<int>("CantHoras")
                        .HasColumnType("int");

                    b.Property<double>("Costo")
                        .HasColumnType("float");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<double>("ValorHora")
                        .HasColumnType("float");

                    b.Property<int>("cod_proyecto")
                        .HasColumnType("int");

                    b.Property<int>("cod_servicio")
                        .HasColumnType("int");

                    b.HasKey("CodTrabajo");

                    b.ToTable("trabajos");

                    b.HasData(
                        new
                        {
                            CodTrabajo = 11,
                            CantHoras = 120,
                            Costo = 180000.0,
                            Fecha = new DateTime(23, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ValorHora = 1500.0,
                            cod_proyecto = 13,
                            cod_servicio = 11
                        },
                        new
                        {
                            CodTrabajo = 12,
                            CantHoras = 50,
                            Costo = 75000.0,
                            Fecha = new DateTime(23, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ValorHora = 1500.0,
                            cod_proyecto = 12,
                            cod_servicio = 11
                        },
                        new
                        {
                            CodTrabajo = 13,
                            CantHoras = 20,
                            Costo = 15000.0,
                            Fecha = new DateTime(23, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ValorHora = 750.0,
                            cod_proyecto = 12,
                            cod_servicio = 12
                        });
                });

            modelBuilder.Entity("ProyectoIntegradorSoftteck.Entities.Usuario", b =>
                {
                    b.Property<int>("CodUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodUsuario"), 1L, 1);

                    b.Property<string>("Contrasena")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Dni")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.HasKey("CodUsuario");

                    b.ToTable("usuarios");

                    b.HasData(
                        new
                        {
                            CodUsuario = 11,
                            Contrasena = "encriptar",
                            Dni = 2020200,
                            Nombre = "Marcio",
                            Tipo = 1
                        },
                        new
                        {
                            CodUsuario = 12,
                            Contrasena = "encriptar",
                            Dni = 1010100,
                            Nombre = "Daniel",
                            Tipo = 1
                        },
                        new
                        {
                            CodUsuario = 13,
                            Contrasena = "encriptar",
                            Dni = 3030300,
                            Nombre = "Pepito",
                            Tipo = 2
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
