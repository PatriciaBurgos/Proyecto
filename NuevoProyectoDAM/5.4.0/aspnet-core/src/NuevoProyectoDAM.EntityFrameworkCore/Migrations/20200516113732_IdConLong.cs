using Microsoft.EntityFrameworkCore.Migrations;

namespace NuevoProyectoDAM.Migrations
{
    public partial class IdConLong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chat_AbpUsers_UsuarioDestinoId1",
                table: "Chat");

            migrationBuilder.DropForeignKey(
                name: "FK_Chat_AbpUsers_UsuarioOrigenId1",
                table: "Chat");

            migrationBuilder.DropForeignKey(
                name: "FK_Publicacion_AbpUsers_UsuarioId1",
                table: "Publicacion");

            migrationBuilder.DropForeignKey(
                name: "FK_PublicacionGustada_AbpUsers_UsuarioId1",
                table: "PublicacionGustada");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioGustado_AbpUsers_UsuarioSeguidoId1",
                table: "UsuarioGustado");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioGustado_AbpUsers_UsuarioSeguidorId1",
                table: "UsuarioGustado");

            migrationBuilder.DropIndex(
                name: "IX_UsuarioGustado_UsuarioSeguidoId1",
                table: "UsuarioGustado");

            migrationBuilder.DropIndex(
                name: "IX_UsuarioGustado_UsuarioSeguidorId1",
                table: "UsuarioGustado");

            migrationBuilder.DropIndex(
                name: "IX_PublicacionGustada_UsuarioId1",
                table: "PublicacionGustada");

            migrationBuilder.DropIndex(
                name: "IX_Publicacion_UsuarioId1",
                table: "Publicacion");

            migrationBuilder.DropIndex(
                name: "IX_Chat_UsuarioDestinoId1",
                table: "Chat");

            migrationBuilder.DropIndex(
                name: "IX_Chat_UsuarioOrigenId1",
                table: "Chat");

            migrationBuilder.DropColumn(
                name: "UsuarioSeguidoId1",
                table: "UsuarioGustado");

            migrationBuilder.DropColumn(
                name: "UsuarioSeguidorId1",
                table: "UsuarioGustado");

            migrationBuilder.DropColumn(
                name: "UsuarioId1",
                table: "PublicacionGustada");

            migrationBuilder.DropColumn(
                name: "UsuarioId1",
                table: "Publicacion");

            migrationBuilder.DropColumn(
                name: "UsuarioDestinoId1",
                table: "Chat");

            migrationBuilder.DropColumn(
                name: "UsuarioOrigenId1",
                table: "Chat");

            migrationBuilder.AlterColumn<long>(
                name: "UsuarioSeguidorId",
                table: "UsuarioGustado",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "UsuarioSeguidoId",
                table: "UsuarioGustado",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "UsuarioId",
                table: "PublicacionGustada",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "UsuarioId",
                table: "Publicacion",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "UsuarioOrigenId",
                table: "Chat",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "UsuarioDestinoId",
                table: "Chat",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioGustado_UsuarioSeguidoId",
                table: "UsuarioGustado",
                column: "UsuarioSeguidoId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioGustado_UsuarioSeguidorId",
                table: "UsuarioGustado",
                column: "UsuarioSeguidorId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicacionGustada_UsuarioId",
                table: "PublicacionGustada",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Publicacion_UsuarioId",
                table: "Publicacion",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Chat_UsuarioDestinoId",
                table: "Chat",
                column: "UsuarioDestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Chat_UsuarioOrigenId",
                table: "Chat",
                column: "UsuarioOrigenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chat_AbpUsers_UsuarioDestinoId",
                table: "Chat",
                column: "UsuarioDestinoId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chat_AbpUsers_UsuarioOrigenId",
                table: "Chat",
                column: "UsuarioOrigenId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Publicacion_AbpUsers_UsuarioId",
                table: "Publicacion",
                column: "UsuarioId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PublicacionGustada_AbpUsers_UsuarioId",
                table: "PublicacionGustada",
                column: "UsuarioId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioGustado_AbpUsers_UsuarioSeguidoId",
                table: "UsuarioGustado",
                column: "UsuarioSeguidoId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioGustado_AbpUsers_UsuarioSeguidorId",
                table: "UsuarioGustado",
                column: "UsuarioSeguidorId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chat_AbpUsers_UsuarioDestinoId",
                table: "Chat");

            migrationBuilder.DropForeignKey(
                name: "FK_Chat_AbpUsers_UsuarioOrigenId",
                table: "Chat");

            migrationBuilder.DropForeignKey(
                name: "FK_Publicacion_AbpUsers_UsuarioId",
                table: "Publicacion");

            migrationBuilder.DropForeignKey(
                name: "FK_PublicacionGustada_AbpUsers_UsuarioId",
                table: "PublicacionGustada");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioGustado_AbpUsers_UsuarioSeguidoId",
                table: "UsuarioGustado");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioGustado_AbpUsers_UsuarioSeguidorId",
                table: "UsuarioGustado");

            migrationBuilder.DropIndex(
                name: "IX_UsuarioGustado_UsuarioSeguidoId",
                table: "UsuarioGustado");

            migrationBuilder.DropIndex(
                name: "IX_UsuarioGustado_UsuarioSeguidorId",
                table: "UsuarioGustado");

            migrationBuilder.DropIndex(
                name: "IX_PublicacionGustada_UsuarioId",
                table: "PublicacionGustada");

            migrationBuilder.DropIndex(
                name: "IX_Publicacion_UsuarioId",
                table: "Publicacion");

            migrationBuilder.DropIndex(
                name: "IX_Chat_UsuarioDestinoId",
                table: "Chat");

            migrationBuilder.DropIndex(
                name: "IX_Chat_UsuarioOrigenId",
                table: "Chat");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioSeguidorId",
                table: "UsuarioGustado",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioSeguidoId",
                table: "UsuarioGustado",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<long>(
                name: "UsuarioSeguidoId1",
                table: "UsuarioGustado",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UsuarioSeguidorId1",
                table: "UsuarioGustado",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "PublicacionGustada",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<long>(
                name: "UsuarioId1",
                table: "PublicacionGustada",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Publicacion",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<long>(
                name: "UsuarioId1",
                table: "Publicacion",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioOrigenId",
                table: "Chat",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioDestinoId",
                table: "Chat",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<long>(
                name: "UsuarioDestinoId1",
                table: "Chat",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UsuarioOrigenId1",
                table: "Chat",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioGustado_UsuarioSeguidoId1",
                table: "UsuarioGustado",
                column: "UsuarioSeguidoId1");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioGustado_UsuarioSeguidorId1",
                table: "UsuarioGustado",
                column: "UsuarioSeguidorId1");

            migrationBuilder.CreateIndex(
                name: "IX_PublicacionGustada_UsuarioId1",
                table: "PublicacionGustada",
                column: "UsuarioId1");

            migrationBuilder.CreateIndex(
                name: "IX_Publicacion_UsuarioId1",
                table: "Publicacion",
                column: "UsuarioId1");

            migrationBuilder.CreateIndex(
                name: "IX_Chat_UsuarioDestinoId1",
                table: "Chat",
                column: "UsuarioDestinoId1");

            migrationBuilder.CreateIndex(
                name: "IX_Chat_UsuarioOrigenId1",
                table: "Chat",
                column: "UsuarioOrigenId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Chat_AbpUsers_UsuarioDestinoId1",
                table: "Chat",
                column: "UsuarioDestinoId1",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Chat_AbpUsers_UsuarioOrigenId1",
                table: "Chat",
                column: "UsuarioOrigenId1",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Publicacion_AbpUsers_UsuarioId1",
                table: "Publicacion",
                column: "UsuarioId1",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PublicacionGustada_AbpUsers_UsuarioId1",
                table: "PublicacionGustada",
                column: "UsuarioId1",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioGustado_AbpUsers_UsuarioSeguidoId1",
                table: "UsuarioGustado",
                column: "UsuarioSeguidoId1",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioGustado_AbpUsers_UsuarioSeguidorId1",
                table: "UsuarioGustado",
                column: "UsuarioSeguidorId1",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
