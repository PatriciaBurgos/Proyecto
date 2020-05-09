using Microsoft.EntityFrameworkCore.Migrations;

namespace DAM.Migrations
{
    public partial class PublicacionAtributosTerminados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publicacion_Aplicacion_AplicacionId",
                table: "Publicacion");

            migrationBuilder.AlterColumn<int>(
                name: "AplicacionId",
                table: "Publicacion",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Publicacion",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Publicacion_UsuarioId",
                table: "Publicacion",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Publicacion_Aplicacion_AplicacionId",
                table: "Publicacion",
                column: "AplicacionId",
                principalTable: "Aplicacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Publicacion_Usuario_UsuarioId",
                table: "Publicacion",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publicacion_Aplicacion_AplicacionId",
                table: "Publicacion");

            migrationBuilder.DropForeignKey(
                name: "FK_Publicacion_Usuario_UsuarioId",
                table: "Publicacion");

            migrationBuilder.DropIndex(
                name: "IX_Publicacion_UsuarioId",
                table: "Publicacion");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Publicacion");

            migrationBuilder.AlterColumn<int>(
                name: "AplicacionId",
                table: "Publicacion",
                type: "int",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Publicacion_Aplicacion_AplicacionId",
                table: "Publicacion",
                column: "AplicacionId",
                principalTable: "Aplicacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
