using Microsoft.EntityFrameworkCore.Migrations;

namespace Next.Platform.Infrastructure.Migrations
{
    public partial class v6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PlayGroundStatus",
                columns: new[] { "Id", "Status" },
                values: new object[] { 4, "Canceled" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PlayGroundStatus",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
