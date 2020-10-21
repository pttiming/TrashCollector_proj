using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class UserRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7bbd1022-288d-4a66-a121-dd0e4d50eb8a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f8491c44-dfaf-4a93-a06a-9d2272dfbb81", "bbec06f9-5850-45c8-bcd5-57db8410d8f0", "Customer", "Customer" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "426a4039-2bb6-46ff-a47c-aa0a96cc512f", "81e34acf-f17e-4c35-988c-f013b96f91fc", "Employee", "Employee" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "7bbd1022-288d-4a66-a121-dd0e4d50eb8a", "bef602f1-3bfc-4d21-b5b2-a31d7acb45b9", "Admin", "ADMIN" });
        }
    }
}
