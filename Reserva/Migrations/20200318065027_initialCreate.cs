using Microsoft.EntityFrameworkCore.Migrations;

namespace Reserva.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "Complejo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Complejo_AdminId",
                table: "Complejo",
                column: "AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_Complejo_Admin_AdminId",
                table: "Complejo",
                column: "AdminId",
                principalTable: "Admin",
                principalColumn: "idAdmin",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Complejo_Admin_AdminId",
                table: "Complejo");

            migrationBuilder.DropIndex(
                name: "IX_Complejo_AdminId",
                table: "Complejo");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Complejo");
        }
    }
}
