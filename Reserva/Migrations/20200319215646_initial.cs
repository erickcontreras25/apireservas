using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Reserva.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    idAdmin = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 20, nullable: true),
                    Email = table.Column<string>(maxLength: 20, nullable: true),
                    Password = table.Column<string>(maxLength: 20, nullable: true),
                    Rol = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.idAdmin);
                });

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
                name: "Usuario",
                columns: table => new
                {
                    idUsuario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 20, nullable: true),
                    NombreUsuario = table.Column<string>(maxLength: 20, nullable: true),
                    Edad = table.Column<decimal>(type: "decimal", nullable: false),
                    Email = table.Column<string>(maxLength: 20, nullable: true),
                    Password = table.Column<string>(maxLength: 20, nullable: true),
                    Rol = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.idUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Complejo",
                columns: table => new
                {
                    idComplejo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 20, nullable: true),
                    Localidad = table.Column<string>(maxLength: 20, nullable: true),
                    CantidadDeCanchas = table.Column<int>(type: "int", nullable: false),
                    idAdmin = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complejo", x => x.idComplejo);
                    table.ForeignKey(
                        name: "FK_Complejo_Admin_idAdmin",
                        column: x => x.idAdmin,
                        principalTable: "Admin",
                        principalColumn: "idAdmin",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipo",
                columns: table => new
                {
                    idEquipo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 20, nullable: true),
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipo", x => x.idEquipo);
                    table.ForeignKey(
                        name: "FK_Equipo_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cancha",
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
                    table.PrimaryKey("PK_Cancha", x => x.idCancha);
                    table.ForeignKey(
                        name: "FK_Cancha_Complejo_idComplejo",
                        column: x => x.idComplejo,
                        principalTable: "Complejo",
                        principalColumn: "idComplejo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservacion",
                columns: table => new
                {
                    idReservacion = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HoraInicial = table.Column<DateTime>(type: "Datetime", nullable: false),
                    HoraFinal = table.Column<DateTime>(type: "Datetime", nullable: false),
                    idCancha = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_Reservacion_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cancha_idComplejo",
                table: "Cancha",
                column: "idComplejo");

            migrationBuilder.CreateIndex(
                name: "IX_Complejo_idAdmin",
                table: "Complejo",
                column: "idAdmin");

            migrationBuilder.CreateIndex(
                name: "IX_Equipo_IdUsuario",
                table: "Equipo",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Reservacion_idCancha",
                table: "Reservacion",
                column: "idCancha");

            migrationBuilder.CreateIndex(
                name: "IX_Reservacion_IdUsuario",
                table: "Reservacion",
                column: "IdUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipo");

            migrationBuilder.DropTable(
                name: "Reservacion");

            migrationBuilder.DropTable(
                name: "Torneo");

            migrationBuilder.DropTable(
                name: "Cancha");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Complejo");

            migrationBuilder.DropTable(
                name: "Admin");
        }
    }
}
