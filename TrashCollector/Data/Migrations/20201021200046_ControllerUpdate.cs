using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class ControllerUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "426a4039-2bb6-46ff-a47c-aa0a96cc512f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8491c44-dfaf-4a93-a06a-9d2272dfbb81");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1284df73-0fca-400b-9a34-a1023b3f5067", "5df5c5ad-3073-4996-b7b4-2890c76c747d", "Customer", "Customer" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "48b6e4c5-5563-426e-a0a7-481bd477434c", "164634aa-2dab-4459-853c-b8b100a60664", "Employee", "Employee" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1284df73-0fca-400b-9a34-a1023b3f5067");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48b6e4c5-5563-426e-a0a7-481bd477434c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f8491c44-dfaf-4a93-a06a-9d2272dfbb81", "bbec06f9-5850-45c8-bcd5-57db8410d8f0", "Customer", "Customer" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "426a4039-2bb6-46ff-a47c-aa0a96cc512f", "81e34acf-f17e-4c35-988c-f013b96f91fc", "Employee", "Employee" });
        }
    }
}
