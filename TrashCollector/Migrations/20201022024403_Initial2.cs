using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "2ad1f778-bd26-4daa-866e-c47872a48371", "581d01b4-4d0c-4c1d-bcc8-319463f28ea3", "Customer", "Customer" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2b0e7a0e-a98d-42c3-a2ef-5d2ec206d46a", "5c09843b-fbb0-4ef8-bd4a-f159386872fe", "Employee", "Employee" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ad1f778-bd26-4daa-866e-c47872a48371");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2b0e7a0e-a98d-42c3-a2ef-5d2ec206d46a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e6e48f6c-c40d-4460-9f56-6e77dc9f448d", "f3ac5c53-fc72-4e5b-9791-d5dadccd3946", "Customer", "Customer" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "87e54ffb-7305-4559-85b7-ccc1d7138b44", "22cd9c1e-99e3-47c8-9c08-7326a1c335fa", "Employee", "Employee" });
        }
    }
}
