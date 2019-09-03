using Microsoft.EntityFrameworkCore.Migrations;

namespace vopen_api.Migrations
{
    public partial class EditionActivityScoreUserEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "EditionsActivitiesScores",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "EditionsActivitiesScores");
        }
    }
}
