using Microsoft.EntityFrameworkCore.Migrations;

namespace DAM.Migrations
{
    public partial class RelacionAplicacionUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_AbpUsers_Aplicacion_AplicacionId",
            //    table: "AbpUsers");

            //migrationBuilder.AlterColumn<int>(
            //    name: "AplicacionId",
            //    table: "AbpUsers",
            //    nullable: true,
            //    oldClrType: typeof(int),
            //    oldType: "int");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_AbpUsers_Aplicacion_AplicacionId",
            //    table: "AbpUsers",
            //    column: "AplicacionId",
            //    principalTable: "Aplicacion",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_AbpUsers_Aplicacion_AplicacionId",
            //    table: "AbpUsers");

            //migrationBuilder.AlterColumn<int>(
            //    name: "AplicacionId",
            //    table: "AbpUsers",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldNullable: true);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_AbpUsers_Aplicacion_AplicacionId",
            //    table: "AbpUsers",
            //    column: "AplicacionId",
            //    principalTable: "Aplicacion",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }
    }
}
