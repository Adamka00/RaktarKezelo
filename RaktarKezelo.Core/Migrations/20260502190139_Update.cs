using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RaktarKezelo.Core.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Termekek_Kategoriak_KategoriaId",
                table: "Termekek");

            migrationBuilder.AlterColumn<string>(
                name: "Megjegyzes",
                table: "Termekek",
                type: "varchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "KategoriaId",
                table: "Termekek",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Ar",
                table: "Termekek",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AddForeignKey(
                name: "FK_Termekek_Kategoriak_KategoriaId",
                table: "Termekek",
                column: "KategoriaId",
                principalTable: "Kategoriak",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Termekek_Kategoriak_KategoriaId",
                table: "Termekek");

            migrationBuilder.AlterColumn<string>(
                name: "Megjegyzes",
                table: "Termekek",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(500)",
                oldMaxLength: 500)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "KategoriaId",
                table: "Termekek",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "Ar",
                table: "Termekek",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddForeignKey(
                name: "FK_Termekek_Kategoriak_KategoriaId",
                table: "Termekek",
                column: "KategoriaId",
                principalTable: "Kategoriak",
                principalColumn: "Id");
        }
    }
}
