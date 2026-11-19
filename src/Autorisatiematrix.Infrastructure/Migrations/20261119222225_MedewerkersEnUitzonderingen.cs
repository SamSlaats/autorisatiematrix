using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Autorisatiematrix.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MedewerkersEnUitzonderingen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medewerkers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Naam = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medewerkers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedewerkerRollen",
                columns: table => new
                {
                    MedewerkerId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RolId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedewerkerRollen", x => new { x.MedewerkerId, x.RolId });
                    table.ForeignKey(
                        name: "FK_MedewerkerRollen_Medewerkers_MedewerkerId",
                        column: x => x.MedewerkerId,
                        principalTable: "Medewerkers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedewerkerRollen_Rollen_RolId",
                        column: x => x.RolId,
                        principalTable: "Rollen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Uitzonderingen",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Reden = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    Eigenaar = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Vervaldatum = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    MedewerkerId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Recht = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uitzonderingen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Uitzonderingen_Medewerkers_MedewerkerId",
                        column: x => x.MedewerkerId,
                        principalTable: "Medewerkers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedewerkerRollen_RolId",
                table: "MedewerkerRollen",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Uitzonderingen_MedewerkerId",
                table: "Uitzonderingen",
                column: "MedewerkerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedewerkerRollen");

            migrationBuilder.DropTable(
                name: "Uitzonderingen");

            migrationBuilder.DropTable(
                name: "Medewerkers");
        }
    }
}
