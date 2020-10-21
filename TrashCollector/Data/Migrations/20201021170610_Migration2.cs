using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class Migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "48342312-18d1-45f9-8e97-edf16b65e8c4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7bbd1022-288d-4a66-a121-dd0e4d50eb8a", "bef602f1-3bfc-4d21-b5b2-a31d7acb45b9", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7bbd1022-288d-4a66-a121-dd0e4d50eb8a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "48342312-18d1-45f9-8e97-edf16b65e8c4", "01732e68-6a24-4cdf-b6db-d0eedb5a4418", "Admin", "ADMIN" });
        }
    }
}
