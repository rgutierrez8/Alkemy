using Microsoft.EntityFrameworkCore.Migrations;

namespace Alkemy.Migrations
{
    public partial class segund : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genero_PeliculaSeries_PeliculaSerieId",
                table: "Genero");

            migrationBuilder.DropIndex(
                name: "IX_Genero_PeliculaSerieId",
                table: "Genero");

            migrationBuilder.DropColumn(
                name: "PeliculaSerieId",
                table: "Genero");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PeliculaSerieId",
                table: "Genero",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Genero_PeliculaSerieId",
                table: "Genero",
                column: "PeliculaSerieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Genero_PeliculaSeries_PeliculaSerieId",
                table: "Genero",
                column: "PeliculaSerieId",
                principalTable: "PeliculaSeries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
