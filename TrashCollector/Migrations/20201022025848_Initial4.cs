using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Migrations
{
    public partial class Initial4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c63ee99-4bb4-4f86-a108-1313e4505667");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ddb6637-d778-408d-8f6f-37c3ea0a646c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b42e9356-25a7-40ff-8159-1a11e2b6597f", "73c48c50-880d-4fca-8727-fdba58bc3d96", "Customer", "Customer" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "59a9f472-6809-4e82-8456-608780c38955", "b1cd5ad0-637d-47d2-bc9c-1501b5772cc7", "Employee", "Employee" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "59a9f472-6809-4e82-8456-608780c38955");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b42e9356-25a7-40ff-8159-1a11e2b6597f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4c63ee99-4bb4-4f86-a108-1313e4505667", "1bda294f-b487-47fc-aef9-5cf5c2278771", "Customer", "Customer" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7ddb6637-d778-408d-8f6f-37c3ea0a646c", "edadbb83-0ae5-4a72-84aa-cdbb16fc0e4f", "Employee", "Employee" });
        }
    }
}
