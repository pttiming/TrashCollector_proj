using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Migrations
{
    public partial class customerpickups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5122206-4fe7-4a1a-8c6e-fd2949f10ee9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fcffccad-b18d-448a-90ac-8b8f479a9c87");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a91521a2-ac5e-4aea-ab80-37d949d22e09", "fb7cb0ff-ed7c-4348-b0e3-6eb09cf0943d", "Customer", "Customer" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6263880d-426f-46d3-9186-d32d453fc65b", "940769fb-d816-4d4f-b800-3ceead1fe210", "Employee", "Employee" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6263880d-426f-46d3-9186-d32d453fc65b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a91521a2-ac5e-4aea-ab80-37d949d22e09");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f5122206-4fe7-4a1a-8c6e-fd2949f10ee9", "2b7a6f09-f862-4b21-adda-0e87bcf61c38", "Customer", "Customer" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fcffccad-b18d-448a-90ac-8b8f479a9c87", "5c1a20c3-2974-471b-a88a-b3143a6b4553", "Employee", "Employee" });
        }
    }
}
