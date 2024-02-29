using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Skateverse.Migrations
{
    public partial class ChangeCategoryIdNameInProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategorieId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1d22e0be-3a48-4b86-8829-9c36fdd3105f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("73de4e16-ee49-43dc-8d90-ccebc3ebacab"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("be379888-f3c5-46c1-a0b1-d80954d1ff6f"));

            migrationBuilder.RenameColumn(
                name: "CategorieId",
                table: "Products",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategorieId",
                table: "Products",
                newName: "IX_Products_CategoryId");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("2af3d2a2-b38a-4f4c-a47c-85364b2a9a8d"), "Jeans" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("2b1abd04-be19-48f4-bf68-fb1ea4c5ce2c"), "Upperwear" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("37281eb1-52c9-4216-a70d-5ef965a6c221"), "Shirts" });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2af3d2a2-b38a-4f4c-a47c-85364b2a9a8d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2b1abd04-be19-48f4-bf68-fb1ea4c5ce2c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("37281eb1-52c9-4216-a70d-5ef965a6c221"));

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Products",
                newName: "CategorieId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                newName: "IX_Products_CategorieId");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("1d22e0be-3a48-4b86-8829-9c36fdd3105f"), "Jeans" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("73de4e16-ee49-43dc-8d90-ccebc3ebacab"), "Upperwear" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("be379888-f3c5-46c1-a0b1-d80954d1ff6f"), "Shirts" });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategorieId",
                table: "Products",
                column: "CategorieId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
