using Microsoft.EntityFrameworkCore.Migrations;

namespace Reserva.Migrations
{
    public partial class actua : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitud",
                table: "Complejo");

            migrationBuilder.DropColumn(
                name: "Longitud",
                table: "Complejo");

            migrationBuilder.AddColumn<string>(
                name: "Localidad",
                table: "Complejo",
                maxLength: 20,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Localidad",
                table: "Complejo");

            migrationBuilder.AddColumn<decimal>(
                name: "Latitud",
                table: "Complejo",
                type: "decimal",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitud",
                table: "Complejo",
                type: "decimal",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
