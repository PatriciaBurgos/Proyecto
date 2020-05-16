using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAM.Migrations
{
    public partial class UserTerminadoConRelaciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chat_Usuario_UsuarioDestinoId",
                table: "Chat");

            migrationBuilder.DropForeignKey(
                name: "FK_Chat_Usuario_UsuarioOrigenId",
                table: "Chat");

            migrationBuilder.DropForeignKey(
                name: "FK_Publicacion_Aplicacion_AplicacionId",
                table: "Publicacion");

            migrationBuilder.DropForeignKey(
                name: "FK_Publicacion_Usuario_UsuarioId",
                table: "Publicacion");

            migrationBuilder.DropForeignKey(
                name: "FK_PublicacionGustada_Usuario_UsuarioId",
                table: "PublicacionGustada");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Aplicacion_AplicacionId",
                table: "Usuario");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioGustado_Usuario_UsuarioSeguidoId",
                table: "UsuarioGustado");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioGustado_Usuario_UsuarioSeguidorId",
                table: "UsuarioGustado");

            migrationBuilder.DropIndex(
                name: "IX_UsuarioGustado_UsuarioSeguidoId",
                table: "UsuarioGustado");

            migrationBuilder.DropIndex(
                name: "IX_UsuarioGustado_UsuarioSeguidorId",
                table: "UsuarioGustado");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_AplicacionId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_PublicacionGustada_UsuarioId",
                table: "PublicacionGustada");

            migrationBuilder.DropIndex(
                name: "IX_Publicacion_AplicacionId",
                table: "Publicacion");

            migrationBuilder.DropIndex(
                name: "IX_Publicacion_UsuarioId",
                table: "Publicacion");

            migrationBuilder.DropIndex(
                name: "IX_Chat_UsuarioDestinoId",
                table: "Chat");

            migrationBuilder.DropIndex(
                name: "IX_Chat_UsuarioOrigenId",
                table: "Chat");

            migrationBuilder.DropColumn(
                name: "Apellido",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "AplicacionId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Ciudad",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Correo",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Cualidades",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "FechaNac",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Municipio",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "NombreUsuario",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "RutaFoto",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "AplicacionId",
                table: "Publicacion");

            migrationBuilder.AddColumn<long>(
                name: "UsuarioSeguidoId1",
                table: "UsuarioGustado",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UsuarioSeguidorId1",
                table: "UsuarioGustado",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UsuarioId1",
                table: "PublicacionGustada",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UsuarioId1",
                table: "Publicacion",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UsuarioDestinoId1",
                table: "Chat",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UsuarioOrigenId1",
                table: "Chat",
                nullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "AplicacionId",
            //    table: "AbpUsers",
            //    nullable: false,
            //    defaultValue: 0);

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

            //migrationBuilder.CreateIndex(
            //    name: "IX_AbpUsers_AplicacionId",
            //    table: "AbpUsers",
            //    column: "AplicacionId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_AbpUsers_Aplicacion_AplicacionId",
            //    table: "AbpUsers",
            //    column: "AplicacionId",
            //    principalTable: "Aplicacion",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.NoAction);

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
                onDelete: ReferentialAction.Restrict);

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
                onDelete: ReferentialAction.Restrict);

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
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_AbpUsers_Aplicacion_AplicacionId",
            //    table: "AbpUsers");

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

            //migrationBuilder.DropIndex(
            //    name: "IX_AbpUsers_AplicacionId",
            //    table: "AbpUsers");

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

            //migrationBuilder.DropColumn(
            //    name: "AplicacionId",
            //    table: "AbpUsers");

            migrationBuilder.AddColumn<string>(
                name: "Apellido",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AplicacionId",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Ciudad",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Correo",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cualidades",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaNac",
                table: "Usuario",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Municipio",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NombreUsuario",
                table: "Usuario",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RutaFoto",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AplicacionId",
                table: "Publicacion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioGustado_UsuarioSeguidoId",
                table: "UsuarioGustado",
                column: "UsuarioSeguidoId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioGustado_UsuarioSeguidorId",
                table: "UsuarioGustado",
                column: "UsuarioSeguidorId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_AplicacionId",
                table: "Usuario",
                column: "AplicacionId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicacionGustada_UsuarioId",
                table: "PublicacionGustada",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Publicacion_AplicacionId",
                table: "Publicacion",
                column: "AplicacionId");

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
                name: "FK_Chat_Usuario_UsuarioDestinoId",
                table: "Chat",
                column: "UsuarioDestinoId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chat_Usuario_UsuarioOrigenId",
                table: "Chat",
                column: "UsuarioOrigenId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Publicacion_Aplicacion_AplicacionId",
                table: "Publicacion",
                column: "AplicacionId",
                principalTable: "Aplicacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Publicacion_Usuario_UsuarioId",
                table: "Publicacion",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PublicacionGustada_Usuario_UsuarioId",
                table: "PublicacionGustada",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Aplicacion_AplicacionId",
                table: "Usuario",
                column: "AplicacionId",
                principalTable: "Aplicacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioGustado_Usuario_UsuarioSeguidoId",
                table: "UsuarioGustado",
                column: "UsuarioSeguidoId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioGustado_Usuario_UsuarioSeguidorId",
                table: "UsuarioGustado",
                column: "UsuarioSeguidorId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
