using Microsoft.EntityFrameworkCore.Migrations;

namespace DAM.Migrations
{
    public partial class RelacionUsuarioAplicacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AplicacionId",
                table: "Usuario",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_AplicacionId",
                table: "Usuario",
                column: "AplicacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Aplicacion_AplicacionId",
                table: "Usuario",
                column: "AplicacionId",
                principalTable: "Aplicacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Aplicacion_AplicacionId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_AplicacionId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "AplicacionId",
                table: "Usuario");
        }
    }
}
