using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Migrations
{
    public partial class CustomerModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3486e020-feb0-418d-80c5-8ca1cc25c86f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a06a60a-a2ef-47f4-a77b-2627887d798d");

            migrationBuilder.DropColumn(
                name: "extraPickup",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "weeklyPickupCompleted",
                table: "Customers");

            migrationBuilder.AlterColumn<decimal>(
                name: "customerBalance",
                table: "Customers",
                type: "decimal(18, 2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "currentMonthlyBalance",
                table: "Customers",
                type: "decimal(18, 2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f5122206-4fe7-4a1a-8c6e-fd2949f10ee9", "2b7a6f09-f862-4b21-adda-0e87bcf61c38", "Customer", "Customer" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fcffccad-b18d-448a-90ac-8b8f479a9c87", "5c1a20c3-2974-471b-a88a-b3143a6b4553", "Employee", "Employee" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5122206-4fe7-4a1a-8c6e-fd2949f10ee9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fcffccad-b18d-448a-90ac-8b8f479a9c87");

            migrationBuilder.AlterColumn<double>(
                name: "customerBalance",
                table: "Customers",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)");

            migrationBuilder.AlterColumn<double>(
                name: "currentMonthlyBalance",
                table: "Customers",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)");

            migrationBuilder.AddColumn<DateTime>(
                name: "extraPickup",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "weeklyPickupCompleted",
                table: "Customers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3486e020-feb0-418d-80c5-8ca1cc25c86f", "c1986816-3ce9-47b1-9925-a5dbe2d8adf2", "Customer", "Customer" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5a06a60a-a2ef-47f4-a77b-2627887d798d", "0bbecf02-a76c-491f-9417-292eac269795", "Employee", "Employee" });
        }
    }
}
