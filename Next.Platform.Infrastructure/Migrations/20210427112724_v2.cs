using Microsoft.EntityFrameworkCore.Migrations;

namespace Next.Platform.Infrastructure.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PlayGroundTypes",
                keyColumn: "Id",
                keyValue: 0);

            migrationBuilder.UpdateData(
                table: "PlayGroundTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Type",
                value: "Ten");

            migrationBuilder.UpdateData(
                table: "PlayGroundTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Type",
                value: "Fourteen");

            migrationBuilder.InsertData(
                table: "PlayGroundTypes",
                columns: new[] { "Id", "Type" },
                values: new object[] { 3, "TwentyOne" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PlayGroundTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "PlayGroundTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Type",
                value: "Fourteen");

            migrationBuilder.UpdateData(
                table: "PlayGroundTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Type",
                value: "TwentyOne");

            migrationBuilder.InsertData(
                table: "PlayGroundTypes",
                columns: new[] { "Id", "Type" },
                values: new object[] { 0, "Ten" });
        }
    }
}
