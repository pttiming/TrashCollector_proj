using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Migrations
{
    public partial class BalanceInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1c55f324-2f85-441e-98bd-78b7a2661f7b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f57c34a-f0a7-4950-8304-d0fbfca137ea");

            migrationBuilder.AddColumn<decimal>(
                name: "currentMonthlyCharges",
                table: "Customers",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "24ba3f26-b05e-46c4-8985-61aedc5f3be2", "3e48afbe-a538-486d-84c3-f50428207513", "Customer", "Customer" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a423437b-ee1c-4cd2-bae8-fd758793ebd3", "e0b0c7dd-271c-4454-bcf6-0dacb228b500", "Employee", "Employee" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24ba3f26-b05e-46c4-8985-61aedc5f3be2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a423437b-ee1c-4cd2-bae8-fd758793ebd3");

            migrationBuilder.DropColumn(
                name: "currentMonthlyCharges",
                table: "Customers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5f57c34a-f0a7-4950-8304-d0fbfca137ea", "e4daefa5-9244-4fee-8f69-d5ea8d746207", "Customer", "Customer" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1c55f324-2f85-441e-98bd-78b7a2661f7b", "de6edea0-de86-4d29-8a4c-0c236e10b28e", "Employee", "Employee" });
        }
    }
}
