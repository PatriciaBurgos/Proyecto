using Microsoft.EntityFrameworkCore.Migrations;

namespace DAM.Migrations
{
    public partial class AplicacionFuera : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_AbpUsers_Aplicacion_AplicacionId",
            //    table: "AbpUsers");

            //migrationBuilder.DropColumn(
            //    name: "Nombre",
            //    table: "Aplicacion");

            //migrationBuilder.AlterColumn<int>(
            //    name: "AplicacionId",
            //    table: "AbpUsers",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int",
            //    oldNullable: true);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_AbpUsers_Aplicacion_AplicacionId",
            //    table: "AbpUsers",
            //    column: "AplicacionId",
            //    principalTable: "Aplicacion",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_AbpUsers_Aplicacion_AplicacionId",
            //    table: "AbpUsers");

            //migrationBuilder.AddColumn<string>(
            //    name: "Nombre",
            //    table: "Aplicacion",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    defaultValue: "");

            //migrationBuilder.AlterColumn<int>(
            //    name: "AplicacionId",
            //    table: "AbpUsers",
            //    type: "int",
            //    nullable: true,
            //    oldClrType: typeof(int));

            //migrationBuilder.AddForeignKey(
            //    name: "FK_AbpUsers_Aplicacion_AplicacionId",
            //    table: "AbpUsers",
            //    column: "AplicacionId",
            //    principalTable: "Aplicacion",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);
        }
    }
}
