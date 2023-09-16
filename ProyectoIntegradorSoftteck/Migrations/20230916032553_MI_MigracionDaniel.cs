using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoIntegradorSoftteck.Migrations
{
    public partial class MI_MigracionDaniel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "proyectos",
                columns: table => new
                {
                    project_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    state = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proyectos", x => x.project_id);
                });

            migrationBuilder.CreateTable(
                name: "services",
                columns: table => new
                {
                    service_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    state = table.Column<bool>(type: "bit", nullable: false),
                    value_hour = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_services", x => x.service_id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dni = table.Column<int>(type: "int", nullable: false),
                    type = table.Column<int>(type: "int", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "works",
                columns: table => new
                {
                    work_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    count_hours = table.Column<int>(type: "int", nullable: false),
                    value_hour = table.Column<double>(type: "float", nullable: false),
                    cost = table.Column<double>(type: "float", nullable: false),
                    project_id = table.Column<int>(type: "int", nullable: false),
                    ProyectoCodProyecto = table.Column<int>(type: "int", nullable: true),
                    service_id = table.Column<int>(type: "int", nullable: false),
                    ServicioCodServicio = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_works", x => x.work_id);
                    table.ForeignKey(
                        name: "FK_works_proyectos_ProyectoCodProyecto",
                        column: x => x.ProyectoCodProyecto,
                        principalTable: "proyectos",
                        principalColumn: "project_id");
                    table.ForeignKey(
                        name: "FK_works_services_ServicioCodServicio",
                        column: x => x.ServicioCodServicio,
                        principalTable: "services",
                        principalColumn: "service_id");
                });

            migrationBuilder.InsertData(
                table: "proyectos",
                columns: new[] { "project_id", "adress", "state", "name" },
                values: new object[,]
                {
                    { 11, "Libertad 180 Carloz Paz", 2, "Renovacion estudio Gomez" },
                    { 12, "Av San Martin S/N Rio Cuarto", 1, "Ampliacion Anfiteatro RC" },
                    { 13, "Colon 1050 Cordoba Capital", 3, "Renovacion Teatro Colon" }
                });

            migrationBuilder.InsertData(
                table: "services",
                columns: new[] { "service_id", "description", "state", "value_hour" },
                values: new object[,]
                {
                    { 11, "Electricidad", true, 1500.0 },
                    { 12, "Plomeria", true, 750.0 },
                    { 13, "Carpintería", true, 900.0 },
                    { 14, "Jardineria", false, 900.0 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "user_id", "password", "dni", "name", "type" },
                values: new object[,]
                {
                    { 11, "2aa98a180fa531837a47595f8128731e0364baab83703c0c19548afb7fce58ff", 2020200, "Marcio", 1 },
                    { 12, "2f6337c78a507bc2f189a1e5540967991313d89f725a01273e72bd1558383706", 1010100, "Daniel", 1 },
                    { 13, "4b4203459fbd2affada5f42ae06d85389c8759e4bb9f343104e150ff0b630ff2", 3030300, "Pepito", 2 }
                });

            migrationBuilder.InsertData(
                table: "works",
                columns: new[] { "work_id", "count_hours", "project_id", "service_id", "cost", "date", "ProyectoCodProyecto", "ServicioCodServicio", "value_hour" },
                values: new object[,]
                {
                    { 11, 120, 13, 11, 180000.0, new DateTime(23, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1500.0 },
                    { 12, 50, 12, 11, 75000.0, new DateTime(23, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1500.0 },
                    { 13, 20, 12, 12, 15000.0, new DateTime(23, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 750.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_works_ProyectoCodProyecto",
                table: "works",
                column: "ProyectoCodProyecto");

            migrationBuilder.CreateIndex(
                name: "IX_works_ServicioCodServicio",
                table: "works",
                column: "ServicioCodServicio");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "works");

            migrationBuilder.DropTable(
                name: "proyectos");

            migrationBuilder.DropTable(
                name: "services");
        }
    }
}
