using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Migrations
{
    public partial class Initial5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "bc62b193-4781-4321-b325-7d35b53e9c33", "315867ee-b572-4ce4-80b4-896969c32860", "Customer", "Customer" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c0073e80-8b07-4312-9fca-55ce67186d17", "25838056-f3de-4665-bcce-fcb766889a84", "Employee", "Employee" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "b42e9356-25a7-40ff-8159-1a11e2b6597f", "73c48c50-880d-4fca-8727-fdba58bc3d96", "Customer", "Customer" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "59a9f472-6809-4e82-8456-608780c38955", "b1cd5ad0-637d-47d2-bc9c-1501b5772cc7", "Employee", "Employee" });
        }
    }
}
