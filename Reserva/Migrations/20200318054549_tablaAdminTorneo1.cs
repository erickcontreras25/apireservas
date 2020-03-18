using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Reserva.Migrations
{
    public partial class tablaAdminTorneo1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Torneo",
                columns: table => new
                {
                    idTorneo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NombreTorneo = table.Column<string>(maxLength: 20, nullable: true),
                    CantidadEquipos = table.Column<decimal>(type: "decimal", nullable: false),
                    Premio = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Torneo", x => x.idTorneo);
                });

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    idAdmin = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 20, nullable: true),
                    Email = table.Column<string>(maxLength: 20, nullable: true),
                    Password = table.Column<string>(maxLength: 20, nullable: true),
                    Rol = table.Column<bool>(type: "bit", nullable: false),
                    IdComplejo = table.Column<int>(type: "int", nullable: false),
                    IdTorneo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.idAdmin);
                    table.ForeignKey(
                        name: "FK_Admin_Complejo_IdComplejo",
                        column: x => x.IdComplejo,
                        principalTable: "Complejo",
                        principalColumn: "idComplejo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Admin_Torneo_IdTorneo",
                        column: x => x.IdTorneo,
                        principalTable: "Torneo",
                        principalColumn: "idTorneo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admin_IdComplejo",
                table: "Admin",
                column: "IdComplejo");

            migrationBuilder.CreateIndex(
                name: "IX_Admin_IdTorneo",
                table: "Admin",
                column: "IdTorneo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Torneo");
        }
    }
}
