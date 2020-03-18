using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Reserva.Migrations
{
    public partial class tablaReser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reservacion",
                columns: table => new
                {
                    idReservacion = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HoraInicial = table.Column<DateTime>(type: "Datetime", nullable: false),
                    HoraFinal = table.Column<DateTime>(type: "Datetime", nullable: false),
                    idCancha = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservacion", x => x.idReservacion);
                    table.ForeignKey(
                        name: "FK_Reservacion_Cancha_idCancha",
                        column: x => x.idCancha,
                        principalTable: "Cancha",
                        principalColumn: "idCancha",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservacion_idCancha",
                table: "Reservacion",
                column: "idCancha");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservacion");
        }
    }
}
