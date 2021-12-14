using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampaignCommander.Data.Migrations
{
    public partial class CampaignRework : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CampaignID",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameID);
                });

            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    CampaignID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaignName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CampaignDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameMasterId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GameID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.CampaignID);
                    table.ForeignKey(
                        name: "FK_Campaigns_AspNetUsers_GameMasterId",
                        column: x => x.GameMasterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Campaigns_Games_GameID",
                        column: x => x.GameID,
                        principalTable: "Games",
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invitation",
                columns: table => new
                {
                    InvitationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaignID = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvitationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invitation", x => new { x.CampaignID, x.InvitationID });
                    table.ForeignKey(
                        name: "FK_Invitation_Campaigns_CampaignID",
                        column: x => x.CampaignID,
                        principalTable: "Campaigns",
                        principalColumn: "CampaignID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CampaignID",
                table: "AspNetUsers",
                column: "CampaignID");

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_GameID",
                table: "Campaigns",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_GameMasterId",
                table: "Campaigns",
                column: "GameMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Campaigns_CampaignID",
                table: "AspNetUsers",
                column: "CampaignID",
                principalTable: "Campaigns",
                principalColumn: "CampaignID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Campaigns_CampaignID",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Invitation");

            migrationBuilder.DropTable(
                name: "Campaigns");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CampaignID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CampaignID",
                table: "AspNetUsers");
        }
    }
}
