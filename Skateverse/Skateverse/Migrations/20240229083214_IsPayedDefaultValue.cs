using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Skateverse.Migrations
{
    public partial class IsPayedDefaultValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("3ce676e9-e236-4405-aba5-6d8d34dfe38d"), "Jeans" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("45234760-5cfe-4625-865d-8fe1fdadce42"), "Upperwear" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("71de3abe-af27-48c0-b2c4-2276bada16bf"), "Shirts" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3ce676e9-e236-4405-aba5-6d8d34dfe38d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("45234760-5cfe-4625-865d-8fe1fdadce42"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("71de3abe-af27-48c0-b2c4-2276bada16bf"));

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
        }
    }
}
