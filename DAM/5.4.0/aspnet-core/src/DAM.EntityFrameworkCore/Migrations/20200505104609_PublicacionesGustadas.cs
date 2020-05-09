using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAM.Migrations
{
    public partial class PublicacionesGustadas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PublicacionGustada",
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
                    UsuarioId = table.Column<int>(nullable: false),
                    PublicacionID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicacionGustada", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PublicacionGustada_Publicacion_PublicacionID",
                        column: x => x.PublicacionID,
                        principalTable: "Publicacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PublicacionGustada_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PublicacionGustada_PublicacionID",
                table: "PublicacionGustada",
                column: "PublicacionID");

            migrationBuilder.CreateIndex(
                name: "IX_PublicacionGustada_UsuarioId",
                table: "PublicacionGustada",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PublicacionGustada");
        }
    }
}
