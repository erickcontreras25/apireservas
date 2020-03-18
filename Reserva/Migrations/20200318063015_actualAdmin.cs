using Microsoft.EntityFrameworkCore.Migrations;

namespace Reserva.Migrations
{
    public partial class actualAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admin_Complejo_IdComplejo",
                table: "Admin");

            migrationBuilder.DropForeignKey(
                name: "FK_Admin_Torneo_IdTorneo",
                table: "Admin");

            migrationBuilder.DropIndex(
                name: "IX_Admin_IdComplejo",
                table: "Admin");

            migrationBuilder.DropIndex(
                name: "IX_Admin_IdTorneo",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "IdComplejo",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "IdTorneo",
                table: "Admin");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdComplejo",
                table: "Admin",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdTorneo",
                table: "Admin",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Admin_IdComplejo",
                table: "Admin",
                column: "IdComplejo");

            migrationBuilder.CreateIndex(
                name: "IX_Admin_IdTorneo",
                table: "Admin",
                column: "IdTorneo");

            migrationBuilder.AddForeignKey(
                name: "FK_Admin_Complejo_IdComplejo",
                table: "Admin",
                column: "IdComplejo",
                principalTable: "Complejo",
                principalColumn: "idComplejo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Admin_Torneo_IdTorneo",
                table: "Admin",
                column: "IdTorneo",
                principalTable: "Torneo",
                principalColumn: "idTorneo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
