using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoIntegradorSoftteck.Migrations
{
    public partial class MI_MigracionOk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "proyectos",
                columns: table => new
                {
                    CodProyecto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proyectos", x => x.CodProyecto);
                });

            migrationBuilder.CreateTable(
                name: "servicios",
                columns: table => new
                {
                    CodServicio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    ValorHora = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_servicios", x => x.CodServicio);
                });

            migrationBuilder.CreateTable(
                name: "trabajos",
                columns: table => new
                {
                    CodTrabajo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CantHoras = table.Column<int>(type: "int", nullable: false),
                    ValorHora = table.Column<double>(type: "float", nullable: false),
                    Costo = table.Column<double>(type: "float", nullable: false),
                    cod_proyecto = table.Column<int>(type: "int", nullable: false),
                    cod_servicio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trabajos", x => x.CodTrabajo);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    CodUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dni = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Contrasena = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.CodUsuario);
                });

            migrationBuilder.InsertData(
                table: "proyectos",
                columns: new[] { "CodProyecto", "Direccion", "Estado", "Nombre" },
                values: new object[,]
                {
                    { 11, "Libertad 180 Carloz Paz", 2, "Renovacion estudio Gomez" },
                    { 12, "Av San Martin S/N Rio Cuarto", 1, "Ampliacion Anfiteatro RC" },
                    { 13, "Colon 1050 Cordoba Capital", 3, "Renovacion Teatro Colon" }
                });

            migrationBuilder.InsertData(
                table: "servicios",
                columns: new[] { "CodServicio", "Descr", "Estado", "ValorHora" },
                values: new object[,]
                {
                    { 11, "Electricidad", true, 1500.0 },
                    { 12, "Plomeria", true, 750.0 },
                    { 13, "Carpintería", true, 900.0 },
                    { 14, "Jardineria", false, 900.0 }
                });

            migrationBuilder.InsertData(
                table: "trabajos",
                columns: new[] { "CodTrabajo", "CantHoras", "Costo", "Fecha", "ValorHora", "cod_proyecto", "cod_servicio" },
                values: new object[,]
                {
                    { 11, 120, 180000.0, new DateTime(23, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1500.0, 13, 11 },
                    { 12, 50, 75000.0, new DateTime(23, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1500.0, 12, 11 },
                    { 13, 20, 15000.0, new DateTime(23, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 750.0, 12, 12 }
                });

            migrationBuilder.InsertData(
                table: "usuarios",
                columns: new[] { "CodUsuario", "Contrasena", "Dni", "Nombre", "Tipo" },
                values: new object[,]
                {
                    { 11, "encriptar", 2020200, "Marcio", 1 },
                    { 12, "encriptar", 1010100, "Daniel", 1 },
                    { 13, "encriptar", 3030300, "Pepito", 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "proyectos");

            migrationBuilder.DropTable(
                name: "servicios");

            migrationBuilder.DropTable(
                name: "trabajos");

            migrationBuilder.DropTable(
                name: "usuarios");
        }
    }
}
