using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Next.Platform.Infrastructure.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MemberStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Neighborhoods",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Neighborhoods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayGroundBookingStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayGroundBookingStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayGroundStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayGroundStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayGroundTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayGroundTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NeighborhoodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admins_Neighborhoods_NeighborhoodId",
                        column: x => x.NeighborhoodId,
                        principalTable: "Neighborhoods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NeighborhoodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MemberStatusId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Owners_MemberStatus_MemberStatusId",
                        column: x => x.MemberStatusId,
                        principalTable: "MemberStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Owners_Neighborhoods_NeighborhoodId",
                        column: x => x.NeighborhoodId,
                        principalTable: "Neighborhoods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NeighborhoodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Neighborhoods_NeighborhoodId",
                        column: x => x.NeighborhoodId,
                        principalTable: "Neighborhoods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayGroundCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NeighborhoodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayGroundCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayGroundCategories_Neighborhoods_NeighborhoodId",
                        column: x => x.NeighborhoodId,
                        principalTable: "Neighborhoods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayGroundCategories_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlayGrounds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    From = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    To = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceEvening = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PriceMorning = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HasBall = table.Column<bool>(type: "bit", nullable: false),
                    HasWater = table.Column<bool>(type: "bit", nullable: false),
                    HasGarag = table.Column<bool>(type: "bit", nullable: false),
                    HasLoacker = table.Column<bool>(type: "bit", nullable: false),
                    HasShower = table.Column<bool>(type: "bit", nullable: false),
                    HasToilet = table.Column<bool>(type: "bit", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlayGroundTypeId = table.Column<int>(type: "int", nullable: false),
                    PlayGroundCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayGroundStatusId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayGrounds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayGrounds_PlayGroundCategories_PlayGroundCategoryId",
                        column: x => x.PlayGroundCategoryId,
                        principalTable: "PlayGroundCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlayGrounds_PlayGroundStatus_PlayGroundStatusId",
                        column: x => x.PlayGroundStatusId,
                        principalTable: "PlayGroundStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayGrounds_PlayGroundTypes_PlayGroundTypeId",
                        column: x => x.PlayGroundTypeId,
                        principalTable: "PlayGroundTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlayGroundId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_PlayGrounds_PlayGroundId",
                        column: x => x.PlayGroundId,
                        principalTable: "PlayGrounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlayGroundBookings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    From = table.Column<DateTime>(type: "datetime2", nullable: false),
                    To = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlayGroundBookingStatusId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayGroundId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayGroundBookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayGroundBookings_PlayGroundBookingStatus_PlayGroundBookingStatusId",
                        column: x => x.PlayGroundBookingStatusId,
                        principalTable: "PlayGroundBookingStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayGroundBookings_PlayGrounds_PlayGroundId",
                        column: x => x.PlayGroundId,
                        principalTable: "PlayGrounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayGroundBookings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateTable(
                name: "PreferredPlayGrounds",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayGroundId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreferredPlayGrounds", x => new { x.UserId, x.PlayGroundId });
                    table.ForeignKey(
                        name: "FK_PreferredPlayGrounds_PlayGrounds_PlayGroundId",
                        column: x => x.PlayGroundId,
                        principalTable: "PlayGrounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PreferredPlayGrounds_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Replay",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Replay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Replay_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Replay_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "MemberStatus",
                columns: new[] { "Id", "Status" },
                values: new object[,]
                {
                    { 0, "Blocked" },
                    { 1, "Banned" },
                    { 2, "Available" }
                });

            migrationBuilder.InsertData(
                table: "PlayGroundBookingStatus",
                columns: new[] { "Id", "Status" },
                values: new object[,]
                {
                    { 0, "Pending" },
                    { 1, "Canceled" },
                    { 2, "Approved" }
                });

            migrationBuilder.InsertData(
                table: "PlayGroundStatus",
                columns: new[] { "Id", "Status" },
                values: new object[,]
                {
                    { 0, "Pending" },
                    { 1, "Closed" },
                    { 2, "Approved" },
                    { 3, "InMaintenance" },
                    { 4, "Canceled" }
                });

            migrationBuilder.InsertData(
                table: "PlayGroundTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Ten" },
                    { 2, "Fourteen" },
                    { 3, "TwentyOne" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_NeighborhoodId",
                table: "Admins",
                column: "NeighborhoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PlayGroundId",
                table: "Comments",
                column: "PlayGroundId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Owners_MemberStatusId",
                table: "Owners",
                column: "MemberStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Owners_NeighborhoodId",
                table: "Owners",
                column: "NeighborhoodId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayGroundBookings_PlayGroundBookingStatusId",
                table: "PlayGroundBookings",
                column: "PlayGroundBookingStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayGroundBookings_PlayGroundId",
                table: "PlayGroundBookings",
                column: "PlayGroundId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayGroundBookings_UserId",
                table: "PlayGroundBookings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayGroundCategories_NeighborhoodId",
                table: "PlayGroundCategories",
                column: "NeighborhoodId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayGroundCategories_OwnerId",
                table: "PlayGroundCategories",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayGroundImages_PlayGroundId",
                table: "PlayGroundImages",
                column: "PlayGroundId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayGrounds_PlayGroundCategoryId",
                table: "PlayGrounds",
                column: "PlayGroundCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayGrounds_PlayGroundStatusId",
                table: "PlayGrounds",
                column: "PlayGroundStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayGrounds_PlayGroundTypeId",
                table: "PlayGrounds",
                column: "PlayGroundTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PreferredPlayGrounds_PlayGroundId",
                table: "PreferredPlayGrounds",
                column: "PlayGroundId");

            migrationBuilder.CreateIndex(
                name: "IX_Replay_CommentId",
                table: "Replay",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Replay_UserId",
                table: "Replay",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_NeighborhoodId",
                table: "Users",
                column: "NeighborhoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PhoneNumber",
                table: "Users",
                column: "PhoneNumber",
                unique: true,
                filter: "[PhoneNumber] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "PlayGroundBookings");

            migrationBuilder.DropTable(
                name: "PlayGroundImages");

            migrationBuilder.DropTable(
                name: "PreferredPlayGrounds");

            migrationBuilder.DropTable(
                name: "Replay");

            migrationBuilder.DropTable(
                name: "PlayGroundBookingStatus");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "PlayGrounds");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "PlayGroundCategories");

            migrationBuilder.DropTable(
                name: "PlayGroundStatus");

            migrationBuilder.DropTable(
                name: "PlayGroundTypes");

            migrationBuilder.DropTable(
                name: "Owners");

            migrationBuilder.DropTable(
                name: "MemberStatus");

            migrationBuilder.DropTable(
                name: "Neighborhoods");
        }
    }
}
