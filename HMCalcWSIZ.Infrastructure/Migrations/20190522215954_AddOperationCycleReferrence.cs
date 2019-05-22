using Microsoft.EntityFrameworkCore.Migrations;

namespace HMCalcWSIZ.Infrastructure.Migrations
{
    public partial class AddOperationCycleReferrence : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "3d68337c-12ce-48d6-9474-2175923813f9", "708ab26e-51b5-4ec9-b938-60e886a795dd" });

            migrationBuilder.AddColumn<int>(
                name: "CycleId",
                table: "Operations",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "86c9dc67-6bdf-40b9-9bb5-30daac4d16f2", "142509ee-05bd-484b-a72f-3147e54096ec", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_Operations_CycleId",
                table: "Operations",
                column: "CycleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Operations_Operations_CycleId",
                table: "Operations",
                column: "CycleId",
                principalTable: "Operations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Operations_Operations_CycleId",
                table: "Operations");

            migrationBuilder.DropIndex(
                name: "IX_Operations_CycleId",
                table: "Operations");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "86c9dc67-6bdf-40b9-9bb5-30daac4d16f2", "142509ee-05bd-484b-a72f-3147e54096ec" });

            migrationBuilder.DropColumn(
                name: "CycleId",
                table: "Operations");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3d68337c-12ce-48d6-9474-2175923813f9", "708ab26e-51b5-4ec9-b938-60e886a795dd", "Admin", "ADMIN" });
        }
    }
}
