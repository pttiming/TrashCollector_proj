using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Migrations
{
    public partial class Initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4b3448a6-13cd-44fd-8001-19b8e01d8410");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de5a714a-0e4f-461a-9526-41ccf9676c0f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e6e48f6c-c40d-4460-9f56-6e77dc9f448d", "f3ac5c53-fc72-4e5b-9791-d5dadccd3946", "Customer", "Customer" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "87e54ffb-7305-4559-85b7-ccc1d7138b44", "22cd9c1e-99e3-47c8-9c08-7326a1c335fa", "Employee", "Employee" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87e54ffb-7305-4559-85b7-ccc1d7138b44");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6e48f6c-c40d-4460-9f56-6e77dc9f448d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4b3448a6-13cd-44fd-8001-19b8e01d8410", "318db963-599f-4d6f-8a81-47b1b4dd5ce8", "Customer", "Customer" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "de5a714a-0e4f-461a-9526-41ccf9676c0f", "de93a834-883e-4c1c-bff2-e2d9434addbe", "Employee", "Employee" });
        }
    }
}
