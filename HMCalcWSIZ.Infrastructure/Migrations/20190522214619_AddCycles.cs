using Microsoft.EntityFrameworkCore.Migrations;

namespace HMCalcWSIZ.Infrastructure.Migrations
{
    public partial class AddCycles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "1d485f46-6d62-47e6-aa3c-a6ae670ac915", "8773591b-a797-4188-8fdc-757711bb0d25" });

            migrationBuilder.AddColumn<bool>(
                name: "IsCycle",
                table: "Operations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3d68337c-12ce-48d6-9474-2175923813f9", "708ab26e-51b5-4ec9-b938-60e886a795dd", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "3d68337c-12ce-48d6-9474-2175923813f9", "708ab26e-51b5-4ec9-b938-60e886a795dd" });

            migrationBuilder.DropColumn(
                name: "IsCycle",
                table: "Operations");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1d485f46-6d62-47e6-aa3c-a6ae670ac915", "8773591b-a797-4188-8fdc-757711bb0d25", "Admin", "ADMIN" });
        }
    }
}
