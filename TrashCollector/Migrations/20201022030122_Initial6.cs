using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Migrations
{
    public partial class Initial6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc62b193-4781-4321-b325-7d35b53e9c33");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0073e80-8b07-4312-9fca-55ce67186d17");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e6bc15ac-aa60-4767-b7f9-ffc75c3d0e93", "b0d6f916-bd7c-4f40-bb17-037fccd5fcab", "Customer", "Customer" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "951b8a27-16da-46f2-9fa8-286d27025082", "9d2f1055-d88a-4bfd-9da6-36d7a503a443", "Employee", "Employee" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "951b8a27-16da-46f2-9fa8-286d27025082");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6bc15ac-aa60-4767-b7f9-ffc75c3d0e93");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bc62b193-4781-4321-b325-7d35b53e9c33", "315867ee-b572-4ce4-80b4-896969c32860", "Customer", "Customer" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c0073e80-8b07-4312-9fca-55ce67186d17", "25838056-f3de-4665-bcce-fcb766889a84", "Employee", "Employee" });
        }
    }
}
