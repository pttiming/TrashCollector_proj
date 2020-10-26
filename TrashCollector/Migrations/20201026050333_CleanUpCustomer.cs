using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Migrations
{
    public partial class CleanUpCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "Name",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "pickupDay",
                table: "Customers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b1ef03d3-1d5a-4075-a65d-51e96399bab5", "084c018f-b773-47e5-a18a-ffb2fd946863", "Customer", "Customer" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "811b9dc1-2a72-46e7-907e-9ea6e6d9478c", "53efb65d-f4e7-4ca3-98ed-8b276dc60796", "Employee", "Employee" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "811b9dc1-2a72-46e7-907e-9ea6e6d9478c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1ef03d3-1d5a-4075-a65d-51e96399bab5");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "Customers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "pickupDay",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "24ba3f26-b05e-46c4-8985-61aedc5f3be2", "3e48afbe-a538-486d-84c3-f50428207513", "Customer", "Customer" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a423437b-ee1c-4cd2-bae8-fd758793ebd3", "e0b0c7dd-271c-4454-bcf6-0dacb228b500", "Employee", "Employee" });
        }
    }
}
