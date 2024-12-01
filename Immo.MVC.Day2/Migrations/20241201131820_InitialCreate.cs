using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Immo.MVC.Day2.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Electronics" },
                    { 2, "Mobiles" },
                    { 3, "Computer" },
                    { 4, "Home Needs" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AddedDate", "CategoryId", "Price", "ProductName", "Quantity" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 1, 18, 48, 20, 598, DateTimeKind.Local).AddTicks(4644), 3, 50000.5m, "HP Laptop", 100 },
                    { 2, new DateTime(2024, 12, 1, 18, 48, 20, 598, DateTimeKind.Local).AddTicks(4661), 4, 850m, "Water Bottle", 252 },
                    { 3, new DateTime(2024, 12, 1, 18, 48, 20, 598, DateTimeKind.Local).AddTicks(4871), 2, 37599.99m, "Apple Watch 7", 15 },
                    { 4, new DateTime(2024, 12, 1, 18, 48, 20, 598, DateTimeKind.Local).AddTicks(4872), 2, 109999.99m, "iPhone 16 Pro", 50 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
