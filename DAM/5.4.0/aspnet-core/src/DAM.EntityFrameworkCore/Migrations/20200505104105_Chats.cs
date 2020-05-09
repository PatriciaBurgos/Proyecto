using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAM.Migrations
{
    public partial class Chats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chat",
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
                    Texto = table.Column<string>(nullable: false),
                    FechaHora = table.Column<DateTime>(nullable: true),
                    IsEnviado = table.Column<bool>(nullable: true),
                    IsRecibido = table.Column<bool>(nullable: true),
                    UsuarioId = table.Column<int>(nullable: false),
                    UsuarioChatId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chat_Usuario_UsuarioChatId",
                        column: x => x.UsuarioChatId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Chat_Usuario_UsuarioId",
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chat");
        }
    }
}
