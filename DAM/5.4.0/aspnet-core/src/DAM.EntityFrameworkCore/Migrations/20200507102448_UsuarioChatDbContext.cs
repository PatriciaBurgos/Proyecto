using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAM.Migrations
{
    public partial class UsuarioChatDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chat_Usuario_UsuarioChatId",
                table: "Chat");

            migrationBuilder.DropForeignKey(
                name: "FK_Chat_Usuario_UsuarioId",
                table: "Chat");

            migrationBuilder.DropTable(
                name: "UsuarioSeguido");

            migrationBuilder.DropIndex(
                name: "IX_Chat_UsuarioChatId",
                table: "Chat");

            migrationBuilder.DropIndex(
                name: "IX_Chat_UsuarioId",
                table: "Chat");

            migrationBuilder.DropColumn(
                name: "UsuarioChatId",
                table: "Chat");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Chat");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioDestinoId",
                table: "Chat",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioOrigenId",
                table: "Chat",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UsuarioGustado",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    UsuarioSeguidorId = table.Column<int>(nullable: false),
                    UsuarioSeguidoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioGustado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioGustado_Usuario_UsuarioSeguidoId",
                        column: x => x.UsuarioSeguidoId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UsuarioGustado_Usuario_UsuarioSeguidorId",
                        column: x => x.UsuarioSeguidorId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chat_UsuarioDestinoId",
                table: "Chat",
                column: "UsuarioDestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Chat_UsuarioOrigenId",
                table: "Chat",
                column: "UsuarioOrigenId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioGustado_UsuarioSeguidoId",
                table: "UsuarioGustado",
                column: "UsuarioSeguidoId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioGustado_UsuarioSeguidorId",
                table: "UsuarioGustado",
                column: "UsuarioSeguidorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chat_Usuario_UsuarioDestinoId",
                table: "Chat",
                column: "UsuarioDestinoId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Chat_Usuario_UsuarioOrigenId",
                table: "Chat",
                column: "UsuarioOrigenId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chat_Usuario_UsuarioDestinoId",
                table: "Chat");

            migrationBuilder.DropForeignKey(
                name: "FK_Chat_Usuario_UsuarioOrigenId",
                table: "Chat");

            migrationBuilder.DropTable(
                name: "UsuarioGustado");

            migrationBuilder.DropIndex(
                name: "IX_Chat_UsuarioDestinoId",
                table: "Chat");

            migrationBuilder.DropIndex(
                name: "IX_Chat_UsuarioOrigenId",
                table: "Chat");

            migrationBuilder.DropColumn(
                name: "UsuarioDestinoId",
                table: "Chat");

            migrationBuilder.DropColumn(
                name: "UsuarioOrigenId",
                table: "Chat");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioChatId",
                table: "Chat",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Chat",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UsuarioSeguido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    SeguidorId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioSeguido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioSeguido_Usuario_SeguidorId",
                        column: x => x.SeguidorId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UsuarioSeguido_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chat_UsuarioChatId",
                table: "Chat",
                column: "UsuarioChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Chat_UsuarioId",
                table: "Chat",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioSeguido_SeguidorId",
                table: "UsuarioSeguido",
                column: "SeguidorId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioSeguido_UsuarioId",
                table: "UsuarioSeguido",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chat_Usuario_UsuarioChatId",
                table: "Chat",
                column: "UsuarioChatId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Chat_Usuario_UsuarioId",
                table: "Chat",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
