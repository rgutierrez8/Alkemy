using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Alkemy.Migrations
{
    public partial class segunda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeneroPelicula_Genero_GeneroNombre",
                table: "GeneroPelicula");

            migrationBuilder.DropIndex(
                name: "IX_GeneroPelicula_GeneroNombre",
                table: "GeneroPelicula");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genero",
                table: "Genero");

            migrationBuilder.DropColumn(
                name: "GeneroNombre",
                table: "GeneroPelicula");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Genero",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genero",
                table: "Genero",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_GeneroPelicula_GeneroId",
                table: "GeneroPelicula",
                column: "GeneroId");

            migrationBuilder.AddForeignKey(
                name: "FK_GeneroPelicula_Genero_GeneroId",
                table: "GeneroPelicula",
                column: "GeneroId",
                principalTable: "Genero",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeneroPelicula_Genero_GeneroId",
                table: "GeneroPelicula");

            migrationBuilder.DropIndex(
                name: "IX_GeneroPelicula_GeneroId",
                table: "GeneroPelicula");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genero",
                table: "Genero");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Genero");

            migrationBuilder.AddColumn<string>(
                name: "GeneroNombre",
                table: "GeneroPelicula",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genero",
                table: "Genero",
                column: "Nombre");

            migrationBuilder.CreateIndex(
                name: "IX_GeneroPelicula_GeneroNombre",
                table: "GeneroPelicula",
                column: "GeneroNombre");

            migrationBuilder.AddForeignKey(
                name: "FK_GeneroPelicula_Genero_GeneroNombre",
                table: "GeneroPelicula",
                column: "GeneroNombre",
                principalTable: "Genero",
                principalColumn: "Nombre",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
