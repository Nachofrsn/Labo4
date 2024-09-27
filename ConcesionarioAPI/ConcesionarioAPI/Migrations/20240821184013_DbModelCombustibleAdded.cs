using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace concesionarioAPI.Migrations
{
    /// <inheritdoc />
    public partial class DbModelCombustibleAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Combustibles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Combustibles", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Combustibles",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Gasolina" },
                    { 2, "Diesel" },
                    { 3, "Gas" },
                    { 4, "Electricidad" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Combustibles");
        }
    }
}
