using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Reserva.Migrations
{
    public partial class crearDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Complejo",
                columns: table => new
                {
                    idComplejo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 20, nullable: true),
                    Latitud = table.Column<decimal>(type: "decimal", nullable: false),
                    Longitud = table.Column<decimal>(type: "decimal", nullable: false),
                    CantidadDeCanchas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complejo", x => x.idComplejo);
                });

            migrationBuilder.CreateTable(
                name: "Canchas",
                columns: table => new
                {
                    idCancha = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Precio = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(maxLength: 20, nullable: true),
                    idComplejo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Canchas", x => x.idCancha);
                    table.ForeignKey(
                        name: "FK_Canchas_Complejo_idComplejo",
                        column: x => x.idComplejo,
                        principalTable: "Complejo",
                        principalColumn: "idComplejo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Canchas_idComplejo",
                table: "Canchas",
                column: "idComplejo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Canchas");

            migrationBuilder.DropTable(
                name: "Complejo");
        }
    }
}
