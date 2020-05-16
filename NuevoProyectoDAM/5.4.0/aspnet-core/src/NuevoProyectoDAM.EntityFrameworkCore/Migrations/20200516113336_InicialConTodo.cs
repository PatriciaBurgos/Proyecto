using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NuevoProyectoDAM.Migrations
{
    public partial class InicialConTodo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "AbpUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AbpUsers",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "AbpUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Qualities",
                table: "AbpUsers",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Town",
                table: "AbpUsers",
                maxLength: 50,
                nullable: true);

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
                    UsuarioOrigenId = table.Column<int>(nullable: false),
                    UsuarioOrigenId1 = table.Column<long>(nullable: true),
                    UsuarioDestinoId = table.Column<int>(nullable: false),
                    UsuarioDestinoId1 = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chat_AbpUsers_UsuarioDestinoId1",
                        column: x => x.UsuarioDestinoId1,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Chat_AbpUsers_UsuarioOrigenId1",
                        column: x => x.UsuarioOrigenId1,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Publicacion",
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
                    Categoria = table.Column<string>(nullable: false),
                    Texto = table.Column<string>(nullable: false),
                    HorarioInicio = table.Column<double>(nullable: true),
                    HorarioFin = table.Column<double>(nullable: true),
                    Municipio = table.Column<string>(nullable: true),
                    Ciudad = table.Column<string>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false),
                    UsuarioId1 = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publicacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Publicacion_AbpUsers_UsuarioId1",
                        column: x => x.UsuarioId1,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                    UsuarioSeguidorId1 = table.Column<long>(nullable: true),
                    UsuarioSeguidoId = table.Column<int>(nullable: false),
                    UsuarioSeguidoId1 = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioGustado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioGustado_AbpUsers_UsuarioSeguidoId1",
                        column: x => x.UsuarioSeguidoId1,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsuarioGustado_AbpUsers_UsuarioSeguidorId1",
                        column: x => x.UsuarioSeguidorId1,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Anuncio",
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
                    Preferencias = table.Column<string>(nullable: true),
                    PublicacionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anuncio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Anuncio_Publicacion_PublicacionId",
                        column: x => x.PublicacionId,
                        principalTable: "Publicacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Peticion",
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
                    IsUrgent = table.Column<bool>(nullable: false),
                    PublicacionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peticion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Peticion_Publicacion_PublicacionId",
                        column: x => x.PublicacionId,
                        principalTable: "Publicacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    UsuarioId1 = table.Column<long>(nullable: true),
                    PublicacionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicacionGustada", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PublicacionGustada_Publicacion_PublicacionId",
                        column: x => x.PublicacionId,
                        principalTable: "Publicacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PublicacionGustada_AbpUsers_UsuarioId1",
                        column: x => x.UsuarioId1,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Anuncio_PublicacionId",
                table: "Anuncio",
                column: "PublicacionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chat_UsuarioDestinoId1",
                table: "Chat",
                column: "UsuarioDestinoId1");

            migrationBuilder.CreateIndex(
                name: "IX_Chat_UsuarioOrigenId1",
                table: "Chat",
                column: "UsuarioOrigenId1");

            migrationBuilder.CreateIndex(
                name: "IX_Peticion_PublicacionId",
                table: "Peticion",
                column: "PublicacionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Publicacion_UsuarioId1",
                table: "Publicacion",
                column: "UsuarioId1");

            migrationBuilder.CreateIndex(
                name: "IX_PublicacionGustada_PublicacionId",
                table: "PublicacionGustada",
                column: "PublicacionId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicacionGustada_UsuarioId1",
                table: "PublicacionGustada",
                column: "UsuarioId1");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioGustado_UsuarioSeguidoId1",
                table: "UsuarioGustado",
                column: "UsuarioSeguidoId1");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioGustado_UsuarioSeguidorId1",
                table: "UsuarioGustado",
                column: "UsuarioSeguidorId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Anuncio");

            migrationBuilder.DropTable(
                name: "Chat");

            migrationBuilder.DropTable(
                name: "Peticion");

            migrationBuilder.DropTable(
                name: "PublicacionGustada");

            migrationBuilder.DropTable(
                name: "UsuarioGustado");

            migrationBuilder.DropTable(
                name: "Publicacion");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "City",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "Qualities",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "Town",
                table: "AbpUsers");
        }
    }
}
