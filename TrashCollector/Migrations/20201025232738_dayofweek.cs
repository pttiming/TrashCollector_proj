using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Migrations
{
    public partial class dayofweek : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6263880d-426f-46d3-9186-d32d453fc65b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a91521a2-ac5e-4aea-ab80-37d949d22e09");

            migrationBuilder.AddColumn<int>(
                name: "DayOfWeek",
                table: "Customers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5f57c34a-f0a7-4950-8304-d0fbfca137ea", "e4daefa5-9244-4fee-8f69-d5ea8d746207", "Customer", "Customer" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1c55f324-2f85-441e-98bd-78b7a2661f7b", "de6edea0-de86-4d29-8a4c-0c236e10b28e", "Employee", "Employee" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1c55f324-2f85-441e-98bd-78b7a2661f7b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f57c34a-f0a7-4950-8304-d0fbfca137ea");

            migrationBuilder.DropColumn(
                name: "DayOfWeek",
                table: "Customers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a91521a2-ac5e-4aea-ab80-37d949d22e09", "fb7cb0ff-ed7c-4348-b0e3-6eb09cf0943d", "Customer", "Customer" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6263880d-426f-46d3-9186-d32d453fc65b", "940769fb-d816-4d4f-b800-3ceead1fe210", "Employee", "Employee" });
        }
    }
}
