using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Migrations
{
    public partial class PickupModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c1aca28-08ce-41c4-8d19-efd7972954b9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "91ac1ab6-2619-42bc-a35c-27fcc94e1369");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3486e020-feb0-418d-80c5-8ca1cc25c86f", "c1986816-3ce9-47b1-9925-a5dbe2d8adf2", "Customer", "Customer" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5a06a60a-a2ef-47f4-a77b-2627887d798d", "0bbecf02-a76c-491f-9417-292eac269795", "Employee", "Employee" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3486e020-feb0-418d-80c5-8ca1cc25c86f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a06a60a-a2ef-47f4-a77b-2627887d798d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8c1aca28-08ce-41c4-8d19-efd7972954b9", "8ad33565-feff-4d7e-95d5-cee49ef80c22", "Customer", "Customer" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "91ac1ab6-2619-42bc-a35c-27fcc94e1369", "286c4196-e27e-4bd2-9a9d-65495aafbe95", "Employee", "Employee" });
        }
    }
}
