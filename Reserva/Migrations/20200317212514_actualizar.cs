using Microsoft.EntityFrameworkCore.Migrations;

namespace Reserva.Migrations
{
    public partial class actualizar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "Reservacion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reservacion_IdUsuario",
                table: "Reservacion",
                column: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservacion_Usuario_IdUsuario",
                table: "Reservacion",
                column: "IdUsuario",
                principalTable: "Usuario",
                principalColumn: "idUsuario",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservacion_Usuario_IdUsuario",
                table: "Reservacion");

            migrationBuilder.DropIndex(
                name: "IX_Reservacion_IdUsuario",
                table: "Reservacion");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "Reservacion");
        }
    }
}
