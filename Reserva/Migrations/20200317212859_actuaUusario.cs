using Microsoft.EntityFrameworkCore.Migrations;

namespace Reserva.Migrations
{
    public partial class actuaUusario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Usuario",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Usuario",
                maxLength: 20,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Usuario");
        }
    }
}
