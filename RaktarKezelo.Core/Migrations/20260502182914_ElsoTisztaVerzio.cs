using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RaktarKezelo.Core.Migrations
{
    /// <inheritdoc />
    public partial class ElsoTisztaVerzio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Kategoriak",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nev = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoriak", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Termekek",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nev = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cikkszam = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Keszlet = table.Column<int>(type: "int", nullable: false),
                    Ar = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    MinKeszlet = table.Column<int>(type: "int", nullable: false),
                    Megjegyzes = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KategoriaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Termekek", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Termekek_Kategoriak_KategoriaId",
                        column: x => x.KategoriaId,
                        principalTable: "Kategoriak",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tranzakciok",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TermekId = table.Column<int>(type: "int", nullable: false),
                    Mennyiseg = table.Column<int>(type: "int", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Tipus = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tranzakciok", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tranzakciok_Termekek_TermekId",
                        column: x => x.TermekId,
                        principalTable: "Termekek",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Termekek_KategoriaId",
                table: "Termekek",
                column: "KategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tranzakciok_TermekId",
                table: "Tranzakciok",
                column: "TermekId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tranzakciok");

            migrationBuilder.DropTable(
                name: "Termekek");

            migrationBuilder.DropTable(
                name: "Kategoriak");
        }
    }
}
