using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Migrations
{
    public partial class Initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ad1f778-bd26-4daa-866e-c47872a48371");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2b0e7a0e-a98d-42c3-a2ef-5d2ec206d46a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4c63ee99-4bb4-4f86-a108-1313e4505667", "1bda294f-b487-47fc-aef9-5cf5c2278771", "Customer", "Customer" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7ddb6637-d778-408d-8f6f-37c3ea0a646c", "edadbb83-0ae5-4a72-84aa-cdbb16fc0e4f", "Employee", "Employee" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "2ad1f778-bd26-4daa-866e-c47872a48371", "581d01b4-4d0c-4c1d-bcc8-319463f28ea3", "Customer", "Customer" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2b0e7a0e-a98d-42c3-a2ef-5d2ec206d46a", "5c09843b-fbb0-4ef8-bd4a-f159386872fe", "Employee", "Employee" });
        }
    }
}
