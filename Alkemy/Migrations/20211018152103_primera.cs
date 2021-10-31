using Microsoft.EntityFrameworkCore.Migrations;

namespace Alkemy.Migrations
{
    public partial class primera : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonajePelicula_PeliculaSeries_PeliculaSerieId",
                table: "PersonajePelicula");

            migrationBuilder.DropColumn(
                name: "PeliculaId",
                table: "PersonajePelicula");

            migrationBuilder.AlterColumn<int>(
                name: "PeliculaSerieId",
                table: "PersonajePelicula",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonajePelicula_PeliculaSeries_PeliculaSerieId",
                table: "PersonajePelicula",
                column: "PeliculaSerieId",
                principalTable: "PeliculaSeries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonajePelicula_PeliculaSeries_PeliculaSerieId",
                table: "PersonajePelicula");

            migrationBuilder.AlterColumn<int>(
                name: "PeliculaSerieId",
                table: "PersonajePelicula",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "PeliculaId",
                table: "PersonajePelicula",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonajePelicula_PeliculaSeries_PeliculaSerieId",
                table: "PersonajePelicula",
                column: "PeliculaSerieId",
                principalTable: "PeliculaSeries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
