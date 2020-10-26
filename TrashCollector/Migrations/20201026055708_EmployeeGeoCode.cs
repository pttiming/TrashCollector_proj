using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Migrations
{
    public partial class EmployeeGeoCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "811b9dc1-2a72-46e7-907e-9ea6e6d9478c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1ef03d3-1d5a-4075-a65d-51e96399bab5");

            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "Employees",
                type: "decimal(10, 8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "Employees",
                type: "decimal(11, 8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "198d336a-cd07-4642-a0f1-60ba946baf0b", "27476591-54b4-4460-b65b-f37a6e6a6b95", "Customer", "Customer" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b23f2bc1-9744-4fb0-b075-7b0d83c60e7d", "5f9a7d3b-c5da-40a7-95df-f153fdc81242", "Employee", "Employee" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "198d336a-cd07-4642-a0f1-60ba946baf0b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b23f2bc1-9744-4fb0-b075-7b0d83c60e7d");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Employees");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b1ef03d3-1d5a-4075-a65d-51e96399bab5", "084c018f-b773-47e5-a18a-ffb2fd946863", "Customer", "Customer" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "811b9dc1-2a72-46e7-907e-9ea6e6d9478c", "53efb65d-f4e7-4ca3-98ed-8b276dc60796", "Employee", "Employee" });
        }
    }
}
