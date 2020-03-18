using Microsoft.EntityFrameworkCore.Migrations;

namespace Reserva.Migrations
{
    public partial class tablaComplejoCancha : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Canchas_Complejo_idComplejo",
                table: "Canchas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Canchas",
                table: "Canchas");

            migrationBuilder.RenameTable(
                name: "Canchas",
                newName: "Cancha");

            migrationBuilder.RenameIndex(
                name: "IX_Canchas_idComplejo",
                table: "Cancha",
                newName: "IX_Cancha_idComplejo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cancha",
                table: "Cancha",
                column: "idCancha");

            migrationBuilder.AddForeignKey(
                name: "FK_Cancha_Complejo_idComplejo",
                table: "Cancha",
                column: "idComplejo",
                principalTable: "Complejo",
                principalColumn: "idComplejo",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cancha_Complejo_idComplejo",
                table: "Cancha");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cancha",
                table: "Cancha");

            migrationBuilder.RenameTable(
                name: "Cancha",
                newName: "Canchas");

            migrationBuilder.RenameIndex(
                name: "IX_Cancha_idComplejo",
                table: "Canchas",
                newName: "IX_Canchas_idComplejo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Canchas",
                table: "Canchas",
                column: "idCancha");

            migrationBuilder.AddForeignKey(
                name: "FK_Canchas_Complejo_idComplejo",
                table: "Canchas",
                column: "idComplejo",
                principalTable: "Complejo",
                principalColumn: "idComplejo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
