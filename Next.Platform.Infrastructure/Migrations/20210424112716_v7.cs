using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Next.Platform.Infrastructure.Migrations
{
    public partial class v7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlayGroundImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlayGroundId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayGroundImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayGroundImages_PlayGrounds_PlayGroundId",
                        column: x => x.PlayGroundId,
                        principalTable: "PlayGrounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayGroundImages_PlayGroundId",
                table: "PlayGroundImages",
                column: "PlayGroundId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayGroundImages");
        }
    }
}
