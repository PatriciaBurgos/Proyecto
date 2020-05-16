using Microsoft.EntityFrameworkCore.Migrations;

namespace DAM.Migrations
{
    public partial class MoreAtributtesUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AbpUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Qualities",
                table: "AbpUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Town",
                table: "AbpUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
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
