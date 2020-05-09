using Microsoft.EntityFrameworkCore.Migrations;

namespace DAM.Migrations
{
    public partial class PublicacionContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Peticion_PublicacionId",
                table: "Peticion");

            migrationBuilder.DropIndex(
                name: "IX_Anuncio_PublicacionId",
                table: "Anuncio");

            migrationBuilder.CreateIndex(
                name: "IX_Peticion_PublicacionId",
                table: "Peticion",
                column: "PublicacionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Anuncio_PublicacionId",
                table: "Anuncio",
                column: "PublicacionId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Peticion_PublicacionId",
                table: "Peticion");

            migrationBuilder.DropIndex(
                name: "IX_Anuncio_PublicacionId",
                table: "Anuncio");

            migrationBuilder.CreateIndex(
                name: "IX_Peticion_PublicacionId",
                table: "Peticion",
                column: "PublicacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Anuncio_PublicacionId",
                table: "Anuncio",
                column: "PublicacionId");
        }
    }
}
