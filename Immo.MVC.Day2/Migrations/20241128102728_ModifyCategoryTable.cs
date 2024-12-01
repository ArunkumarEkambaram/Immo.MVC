using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Immo.MVC.Day2.Migrations
{
    public partial class ModifyCategoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TestColumn",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TestColumn",
                table: "Categories");
        }
    }
}
