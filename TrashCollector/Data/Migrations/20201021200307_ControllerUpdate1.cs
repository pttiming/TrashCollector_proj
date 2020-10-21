using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class ControllerUpdate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "b2dfcbe9-d632-4420-9c57-f57aacf37f57", "03fa79d6-9c47-4367-a184-01f19d7ce466", "Customer", "Customer" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "12368069-32a3-4815-9a84-c2cf2b4658e5", "fd242318-db89-499d-8e24-2cca3fe2d9cd", "Employee", "Employee" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12368069-32a3-4815-9a84-c2cf2b4658e5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b2dfcbe9-d632-4420-9c57-f57aacf37f57");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1284df73-0fca-400b-9a34-a1023b3f5067", "5df5c5ad-3073-4996-b7b4-2890c76c747d", "Customer", "Customer" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "48b6e4c5-5563-426e-a0a7-481bd477434c", "164634aa-2dab-4459-853c-b8b100a60664", "Employee", "Employee" });
        }
    }
}
