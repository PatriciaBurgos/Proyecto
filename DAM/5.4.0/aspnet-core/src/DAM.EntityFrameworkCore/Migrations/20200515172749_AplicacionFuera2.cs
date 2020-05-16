using Microsoft.EntityFrameworkCore.Migrations;

namespace DAM.Migrations
{
    public partial class AplicacionFuera2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_AbpUsers_Aplicacion_AplicacionId",
            //    table: "AbpUsers");

        //    migrationBuilder.DropIndex(
        //        name: "IX_AbpUsers_AplicacionId",
        //        table: "AbpUsers");

        //    migrationBuilder.DropColumn(
        //        name: "AplicacionId",
        //        table: "AbpUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<int>(
            //    name: "AplicacionId",
            //    table: "AbpUsers",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);

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
            //    onDelete: ReferentialAction.Cascade);
        }
    }
}
