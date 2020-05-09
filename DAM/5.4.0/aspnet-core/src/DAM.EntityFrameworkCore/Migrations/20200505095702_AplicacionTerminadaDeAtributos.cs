using Microsoft.EntityFrameworkCore.Migrations;

namespace DAM.Migrations
{
    public partial class AplicacionTerminadaDeAtributos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AplicacionId",
                table: "Publicacion",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Publicacion_AplicacionId",
                table: "Publicacion",
                column: "AplicacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Publicacion_Aplicacion_AplicacionId",
                table: "Publicacion",
                column: "AplicacionId",
                principalTable: "Aplicacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publicacion_Aplicacion_AplicacionId",
                table: "Publicacion");

            migrationBuilder.DropIndex(
                name: "IX_Publicacion_AplicacionId",
                table: "Publicacion");

            migrationBuilder.DropColumn(
                name: "AplicacionId",
                table: "Publicacion");
        }
    }
}
