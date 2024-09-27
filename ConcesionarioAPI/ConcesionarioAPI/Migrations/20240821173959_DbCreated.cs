using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace concesionarioAPI.Migrations
{
    /// <inheritdoc />
    public partial class DbCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoCombustible = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Transmision = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TieneEstereo = table.Column<bool>(type: "bit", nullable: false),
                    CantidadPuertas = table.Column<int>(type: "int", nullable: false),
                    FechaFabricacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Autos",
                columns: new[] { "Id", "CantidadPuertas", "FechaFabricacion", "Marca", "Modelo", "TieneEstereo", "TipoCombustible", "Transmision" },
                values: new object[,]
                {
                    { 1, 4, new DateTime(2020, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Toyota", "Corolla", true, "Gasolina", "Automática" },
                    { 2, 4, new DateTime(2019, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Honda", "Civic", true, "Gasolina", "Manual" },
                    { 3, 4, new DateTime(2021, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ford", "Focus", false, "Diesel", "Automática" },
                    { 4, 4, new DateTime(2022, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chevrolet", "Cruze", true, "Gasolina", "Automática" },
                    { 5, 4, new DateTime(2018, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Volkswagen", "Golf", false, "Gasolina", "Manual" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Autos");
        }
    }
}
