using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampaignCommander.Data.Migrations
{
    public partial class AddedGameNavPropertyToCampaigns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campaigns_Games_GameID",
                table: "Campaigns");

            migrationBuilder.RenameColumn(
                name: "GameID",
                table: "Campaigns",
                newName: "GameId");

            migrationBuilder.RenameIndex(
                name: "IX_Campaigns_GameID",
                table: "Campaigns",
                newName: "IX_Campaigns_GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Campaigns_Games_GameId",
                table: "Campaigns",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campaigns_Games_GameId",
                table: "Campaigns");

            migrationBuilder.RenameColumn(
                name: "GameId",
                table: "Campaigns",
                newName: "GameID");

            migrationBuilder.RenameIndex(
                name: "IX_Campaigns_GameId",
                table: "Campaigns",
                newName: "IX_Campaigns_GameID");

            migrationBuilder.AddForeignKey(
                name: "FK_Campaigns_Games_GameID",
                table: "Campaigns",
                column: "GameID",
                principalTable: "Games",
                principalColumn: "GameID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
