using Microsoft.EntityFrameworkCore.Migrations;

namespace HMCalcWSIZ.Infrastructure.Migrations
{
    public partial class UpdateOperation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "353648b6-0b9e-4eb5-804e-5153f96b2c73", "34d1f40e-82fc-4046-a9f3-75b1e1f74ad1" });

            migrationBuilder.AddColumn<bool>(
                name: "IsIncome",
                table: "Operations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1d485f46-6d62-47e6-aa3c-a6ae670ac915", "8773591b-a797-4188-8fdc-757711bb0d25", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "1d485f46-6d62-47e6-aa3c-a6ae670ac915", "8773591b-a797-4188-8fdc-757711bb0d25" });

            migrationBuilder.DropColumn(
                name: "IsIncome",
                table: "Operations");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "353648b6-0b9e-4eb5-804e-5153f96b2c73", "34d1f40e-82fc-4046-a9f3-75b1e1f74ad1", "Admin", "ADMIN" });
        }
    }
}
