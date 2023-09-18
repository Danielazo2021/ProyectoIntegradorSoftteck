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
                        .HasColumnType("int")
                        .HasColumnName("project_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodProyecto"), 1L, 1);

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("adress");

                    b.Property<int>("Estado")
                        .HasColumnType("int")
                        .HasColumnName("state");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("CodProyecto");

                    b.ToTable("projects");

                    b.HasData(
                        new
                        {
                            CodProyecto = 11,
                            Direccion = "Libertad 180 Carloz Paz",
                            Estado = 3,
                            Nombre = "Optimización de Procesos de Refinamiento de Petróleo CrudoManolita y Cia"
                        },
                        new
                        {
                            CodProyecto = 12,
                            Direccion = "Av San Martin S/N Rio Cuarto",
                            Estado = 1,
                            Nombre = "Programa de Mantenimiento y Actualización de Equipos"
                        },
                        new
                        {
                            CodProyecto = 13,
                            Direccion = "Colon 1050 Cordoba Capital",
                            Estado = 2,
                            Nombre = "Modernización de la Refinería para Carmelo SA"
                        });
                });

            modelBuilder.Entity("ProyectoIntegradorSoftteck.Entities.Servicio", b =>
                {
                    b.Property<int>("CodServicio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("service_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodServicio"), 1L, 1);

                    b.Property<string>("Descr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit")
                        .HasColumnName("state");

                    b.Property<double>("ValorHora")
                        .HasColumnType("float")
                        .HasColumnName("value_hour");

                    b.HasKey("CodServicio");

                    b.ToTable("services");

                    b.HasData(
                        new
                        {
                            CodServicio = 11,
                            Descr = "Refinamiento de Petróleo Crudo",
                            Estado = true,
                            ValorHora = 150000.0
                        },
                        new
                        {
                            CodServicio = 12,
                            Descr = "Desulfuración de Combustibles",
                            Estado = true,
                            ValorHora = 75000.0
                        },
                        new
                        {
                            CodServicio = 13,
                            Descr = "Mantenimiento y Reparación de Equipos de Refinería",
                            Estado = true,
                            ValorHora = 90000.0
                        },
                        new
                        {
                            CodServicio = 14,
                            Descr = "Consultoría en Eficiencia Energética y Ambiental",
                            Estado = false,
                            ValorHora = 90000.0
                        });
                });

            modelBuilder.Entity("ProyectoIntegradorSoftteck.Entities.Trabajo", b =>
                {
                    b.Property<int>("CodTrabajo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("work_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodTrabajo"), 1L, 1);

                    b.Property<int>("CantHoras")
                        .HasColumnType("int")
                        .HasColumnName("count_hours");

                    b.Property<int>("Cod_proyecto")
                        .HasColumnType("int")
                        .HasColumnName("project_id");

                    b.Property<int>("Cod_servicio")
                        .HasColumnType("int")
                        .HasColumnName("service_id");

                    b.Property<double>("Costo")
                        .HasColumnType("float")
                        .HasColumnName("cost");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2")
                        .HasColumnName("date");

                    b.Property<double>("ValorHora")
                        .HasColumnType("float")
                        .HasColumnName("value_hour");

                    b.HasKey("CodTrabajo");

                    b.HasIndex("Cod_proyecto");

                    b.HasIndex("Cod_servicio");

                    b.ToTable("works");

                    b.HasData(
                        new
                        {
                            CodTrabajo = 11,
                            CantHoras = 120,
                            Cod_proyecto = 13,
                            Cod_servicio = 11,
                            Costo = 18000000.0,
                            Fecha = new DateTime(23, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ValorHora = 150000.0
                        },
                        new
                        {
                            CodTrabajo = 12,
                            CantHoras = 50,
                            Cod_proyecto = 12,
                            Cod_servicio = 11,
                            Costo = 7500000.0,
                            Fecha = new DateTime(23, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ValorHora = 150000.0
                        },
                        new
                        {
                            CodTrabajo = 13,
                            CantHoras = 20,
                            Cod_proyecto = 12,
                            Cod_servicio = 12,
                            Costo = 1500000.0,
                            Fecha = new DateTime(23, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ValorHora = 75000.0
                        });
                });

            modelBuilder.Entity("ProyectoIntegradorSoftteck.Entities.Usuario", b =>
                {
                    b.Property<int>("CodUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodUsuario"), 1L, 1);

                    b.Property<string>("Contrasena")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password");

                    b.Property<int>("Dni")
                        .HasColumnType("int")
                        .HasColumnName("dni");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<int>("Tipo")
                        .HasColumnType("int")
                        .HasColumnName("type");

                    b.HasKey("CodUsuario");

                    b.ToTable("users");

                    b.HasData(
                        new
                        {
                            CodUsuario = 11,
                            Contrasena = "2aa98a180fa531837a47595f8128731e0364baab83703c0c19548afb7fce58ff",
                            Dni = 2020200,
                            Nombre = "Marcio",
                            Tipo = 1
                        },
                        new
                        {
                            CodUsuario = 12,
                            Contrasena = "2f6337c78a507bc2f189a1e5540967991313d89f725a01273e72bd1558383706",
                            Dni = 1010100,
                            Nombre = "Daniel",
                            Tipo = 1
                        },
                        new
                        {
                            CodUsuario = 13,
                            Contrasena = "4b4203459fbd2affada5f42ae06d85389c8759e4bb9f343104e150ff0b630ff2",
                            Dni = 3030300,
                            Nombre = "Pepito",
                            Tipo = 2
                        });
                });

            modelBuilder.Entity("ProyectoIntegradorSoftteck.Entities.Trabajo", b =>
                {
                    b.HasOne("ProyectoIntegradorSoftteck.Entities.Proyecto", "Proyecto")
                        .WithMany()
                        .HasForeignKey("Cod_proyecto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoIntegradorSoftteck.Entities.Servicio", "Servicio")
                        .WithMany()
                        .HasForeignKey("Cod_servicio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proyecto");

                    b.Navigation("Servicio");
                });
#pragma warning restore 612, 618
        }
    }
}
