using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

namespace TrashCollector.Migrations
{
    public partial class Initial7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "951b8a27-16da-46f2-9fa8-286d27025082");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6bc15ac-aa60-4767-b7f9-ffc75c3d0e93");

            migrationBuilder.AlterColumn<Geometry>(
                name: "LocationID",
                table: "Customers",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a24cf2d4-723e-49ff-bbaf-5f0b7323c3a8", "a307ba33-9c2e-4a3b-8f54-f864bac6bb2d", "Customer", "Customer" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "de652f6d-076a-43ad-9908-6113d92f6708", "29638cd3-bffd-4162-8f3b-6a37cb4efeff", "Employee", "Employee" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a24cf2d4-723e-49ff-bbaf-5f0b7323c3a8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de652f6d-076a-43ad-9908-6113d92f6708");

            migrationBuilder.AlterColumn<string>(
                name: "LocationID",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Geometry),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e6bc15ac-aa60-4767-b7f9-ffc75c3d0e93", "b0d6f916-bd7c-4f40-bb17-037fccd5fcab", "Customer", "Customer" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "951b8a27-16da-46f2-9fa8-286d27025082", "9d2f1055-d88a-4bfd-9da6-36d7a503a443", "Employee", "Employee" });
        }
    }
}
