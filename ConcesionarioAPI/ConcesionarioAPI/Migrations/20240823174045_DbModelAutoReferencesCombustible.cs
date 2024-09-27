using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace concesionarioAPI.Migrations
{
    /// <inheritdoc />
    public partial class DbModelAutoReferencesCombustible : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoCombustible",
                table: "Autos");

            migrationBuilder.AddColumn<int>(
                name: "CombustibleId",
                table: "Autos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Autos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CombustibleId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Autos",
                keyColumn: "Id",
                keyValue: 2,
                column: "CombustibleId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Autos",
                keyColumn: "Id",
                keyValue: 3,
                column: "CombustibleId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Autos",
                keyColumn: "Id",
                keyValue: 4,
                column: "CombustibleId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Autos",
                keyColumn: "Id",
                keyValue: 5,
                column: "CombustibleId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Autos_CombustibleId",
                table: "Autos",
                column: "CombustibleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Autos_Combustibles_CombustibleId",
                table: "Autos",
                column: "CombustibleId",
                principalTable: "Combustibles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Autos_Combustibles_CombustibleId",
                table: "Autos");

            migrationBuilder.DropIndex(
                name: "IX_Autos_CombustibleId",
                table: "Autos");

            migrationBuilder.DropColumn(
                name: "CombustibleId",
                table: "Autos");

            migrationBuilder.AddColumn<string>(
                name: "TipoCombustible",
                table: "Autos",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Autos",
                keyColumn: "Id",
                keyValue: 1,
                column: "TipoCombustible",
                value: "Gasolina");

            migrationBuilder.UpdateData(
                table: "Autos",
                keyColumn: "Id",
                keyValue: 2,
                column: "TipoCombustible",
                value: "Gasolina");

            migrationBuilder.UpdateData(
                table: "Autos",
                keyColumn: "Id",
                keyValue: 3,
                column: "TipoCombustible",
                value: "Diesel");

            migrationBuilder.UpdateData(
                table: "Autos",
                keyColumn: "Id",
                keyValue: 4,
                column: "TipoCombustible",
                value: "Gasolina");

            migrationBuilder.UpdateData(
                table: "Autos",
                keyColumn: "Id",
                keyValue: 5,
                column: "TipoCombustible",
                value: "Gasolina");
        }
    }
}
