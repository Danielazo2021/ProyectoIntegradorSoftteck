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
                name: "projects",
                columns: table => new
                {
                    project_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    state = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projects", x => x.project_id);
                });

            migrationBuilder.CreateTable(
                name: "services",
                columns: table => new
                {
                    service_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    state = table.Column<bool>(type: "bit", nullable: false),
                    value_hour = table.Column<double>(type: "float", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false)
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
                    user_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dni = table.Column<int>(type: "int", nullable: false),
                    type = table.Column<int>(type: "int", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false)
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
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    project_id = table.Column<int>(type: "int", nullable: false),
                    service_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_works", x => x.work_id);
                    table.ForeignKey(
                        name: "FK_works_projects_project_id",
                        column: x => x.project_id,
                        principalTable: "projects",
                        principalColumn: "project_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_works_services_service_id",
                        column: x => x.service_id,
                        principalTable: "services",
                        principalColumn: "service_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "projects",
                columns: new[] { "project_id", "adress", "state", "is_active", "name" },
                values: new object[,]
                {
                    { 1, "Libertad 180 Carloz Paz", "Terminado", true, "Optimización de Procesos de Refinamiento de Petróleo CrudoManolita y Cia" },
                    { 2, "Av San Martin S/N Rio Cuarto", "Pendiente", true, "Programa de Mantenimiento y Actualización de Equipos" },
                    { 3, "Colon 1050 Cordoba Capital", "Confirmado", true, "Modernización de la Refinería para Carmelo SA" }
                });

            migrationBuilder.InsertData(
                table: "services",
                columns: new[] { "service_id", "description", "state", "is_active", "value_hour" },
                values: new object[,]
                {
                    { 1, "Refinamiento de Petróleo Crudo", true, true, 150000.0 },
                    { 2, "Desulfuración de Combustibles", true, true, 75000.0 },
                    { 3, "Mantenimiento y Reparación de Equipos de Refinería", true, true, 90000.0 },
                    { 4, "Consultoría en Eficiencia Energética y Ambiental", false, true, 90000.0 }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "user_id", "password", "dni", "email", "is_active", "name", "type", "user_name" },
                values: new object[,]
                {
                    { 1, "0bafc68a2ce2898800fc9ce5d19d99b47a828cbb3453712fec676aa2dbc290e6", 2020200, "marcio@marcio.com", true, "Marcio", 1, "ProfeMarcio" },
                    { 2, "ceea4b372a2f951d90f7ae0342989b9643978119756141db7af70a0c9b621c64", 1010100, "daniel@daniel.com", true, "Daniel", 1, "Danielazo" },
                    { 3, "374600eb00b38ae69c41d6a1fb91dc2d0ddbacac5d3a165d0ff546549fe2078c", 3030300, "pepe@pepe.com", true, "Pepe", 2, "Pepito" }
                });

            migrationBuilder.InsertData(
                table: "works",
                columns: new[] { "work_id", "count_hours", "project_id", "service_id", "cost", "date", "is_active", "value_hour" },
                values: new object[] { 1, 120, 3, 1, 18000000.0, new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 150000.0 });

            migrationBuilder.InsertData(
                table: "works",
                columns: new[] { "work_id", "count_hours", "project_id", "service_id", "cost", "date", "is_active", "value_hour" },
                values: new object[] { 2, 50, 2, 1, 7500000.0, new DateTime(2023, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 150000.0 });

            migrationBuilder.InsertData(
                table: "works",
                columns: new[] { "work_id", "count_hours", "project_id", "service_id", "cost", "date", "is_active", "value_hour" },
                values: new object[] { 3, 20, 2, 2, 1500000.0, new DateTime(2023, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 75000.0 });

            migrationBuilder.CreateIndex(
                name: "IX_works_project_id",
                table: "works",
                column: "project_id");

            migrationBuilder.CreateIndex(
                name: "IX_works_service_id",
                table: "works",
                column: "service_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "works");

            migrationBuilder.DropTable(
                name: "projects");

            migrationBuilder.DropTable(
                name: "services");
        }
    }
}
