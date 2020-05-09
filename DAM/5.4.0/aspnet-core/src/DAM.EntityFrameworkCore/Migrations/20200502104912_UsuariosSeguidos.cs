using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAM.Migrations
{
    public partial class UsuariosSeguidos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsuarioSeguido",
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
                    IdUsuario = table.Column<int>(nullable: false),
                    IdSeguidor = table.Column<int>(nullable: false),
                    IdSeguidorNavigationId = table.Column<int>(nullable: true),
                    IdUsuarioNavigationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioSeguido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioSeguido_Usuario_IdSeguidorNavigationId",
                        column: x => x.IdSeguidorNavigationId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsuarioSeguido_Usuario_IdUsuarioNavigationId",
                        column: x => x.IdUsuarioNavigationId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioSeguido_IdSeguidorNavigationId",
                table: "UsuarioSeguido",
                column: "IdSeguidorNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioSeguido_IdUsuarioNavigationId",
                table: "UsuarioSeguido",
                column: "IdUsuarioNavigationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuarioSeguido");
        }
    }
}
