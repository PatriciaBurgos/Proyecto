using Microsoft.EntityFrameworkCore.Migrations;

namespace DAM.Migrations
{
    public partial class UsuarioGustadoPrueba : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PublicacionGustada_Publicacion_PublicacionID",
                table: "PublicacionGustada");

            migrationBuilder.RenameColumn(
                name: "PublicacionID",
                table: "PublicacionGustada",
                newName: "PublicacionId");

            migrationBuilder.RenameIndex(
                name: "IX_PublicacionGustada_PublicacionID",
                table: "PublicacionGustada",
                newName: "IX_PublicacionGustada_PublicacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_PublicacionGustada_Publicacion_PublicacionId",
                table: "PublicacionGustada",
                column: "PublicacionId",
                principalTable: "Publicacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PublicacionGustada_Publicacion_PublicacionId",
                table: "PublicacionGustada");

            migrationBuilder.RenameColumn(
                name: "PublicacionId",
                table: "PublicacionGustada",
                newName: "PublicacionID");

            migrationBuilder.RenameIndex(
                name: "IX_PublicacionGustada_PublicacionId",
                table: "PublicacionGustada",
                newName: "IX_PublicacionGustada_PublicacionID");

            migrationBuilder.AddForeignKey(
                name: "FK_PublicacionGustada_Publicacion_PublicacionID",
                table: "PublicacionGustada",
                column: "PublicacionID",
                principalTable: "Publicacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
