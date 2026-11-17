using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Autorisatiematrix.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EersteMigratie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rollen",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Naam = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rollen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RolRechten",
                columns: table => new
                {
                    Recht = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    RolId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolRechten", x => new { x.RolId, x.Recht });
                    table.ForeignKey(
                        name: "FK_RolRechten_Rollen_RolId",
                        column: x => x.RolId,
                        principalTable: "Rollen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RolRechten");

            migrationBuilder.DropTable(
                name: "Rollen");
        }
    }
}
