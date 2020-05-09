using Microsoft.EntityFrameworkCore.Migrations;

namespace DAM.Migrations
{
    public partial class UsuariosSeguidosAtributps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioSeguido_Usuario_IdSeguidorNavigationId",
                table: "UsuarioSeguido");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioSeguido_Usuario_IdUsuarioNavigationId",
                table: "UsuarioSeguido");

            migrationBuilder.DropIndex(
                name: "IX_UsuarioSeguido_IdSeguidorNavigationId",
                table: "UsuarioSeguido");

            migrationBuilder.DropIndex(
                name: "IX_UsuarioSeguido_IdUsuarioNavigationId",
                table: "UsuarioSeguido");

            migrationBuilder.DropColumn(
                name: "IdSeguidor",
                table: "UsuarioSeguido");

            migrationBuilder.DropColumn(
                name: "IdSeguidorNavigationId",
                table: "UsuarioSeguido");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "UsuarioSeguido");

            migrationBuilder.DropColumn(
                name: "IdUsuarioNavigationId",
                table: "UsuarioSeguido");

            migrationBuilder.AddColumn<int>(
                name: "SeguidorId",
                table: "UsuarioSeguido",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "UsuarioSeguido",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioSeguido_SeguidorId",
                table: "UsuarioSeguido",
                column: "SeguidorId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioSeguido_UsuarioId",
                table: "UsuarioSeguido",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioSeguido_Usuario_SeguidorId",
                table: "UsuarioSeguido",
                column: "SeguidorId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioSeguido_Usuario_UsuarioId",
                table: "UsuarioSeguido",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioSeguido_Usuario_SeguidorId",
                table: "UsuarioSeguido");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioSeguido_Usuario_UsuarioId",
                table: "UsuarioSeguido");

            migrationBuilder.DropIndex(
                name: "IX_UsuarioSeguido_SeguidorId",
                table: "UsuarioSeguido");

            migrationBuilder.DropIndex(
                name: "IX_UsuarioSeguido_UsuarioId",
                table: "UsuarioSeguido");

            migrationBuilder.DropColumn(
                name: "SeguidorId",
                table: "UsuarioSeguido");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "UsuarioSeguido");

            migrationBuilder.AddColumn<int>(
                name: "IdSeguidor",
                table: "UsuarioSeguido",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdSeguidorNavigationId",
                table: "UsuarioSeguido",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "UsuarioSeguido",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdUsuarioNavigationId",
                table: "UsuarioSeguido",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioSeguido_IdSeguidorNavigationId",
                table: "UsuarioSeguido",
                column: "IdSeguidorNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioSeguido_IdUsuarioNavigationId",
                table: "UsuarioSeguido",
                column: "IdUsuarioNavigationId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioSeguido_Usuario_IdSeguidorNavigationId",
                table: "UsuarioSeguido",
                column: "IdSeguidorNavigationId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioSeguido_Usuario_IdUsuarioNavigationId",
                table: "UsuarioSeguido",
                column: "IdUsuarioNavigationId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
