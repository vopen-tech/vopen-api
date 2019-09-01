using Microsoft.EntityFrameworkCore.Migrations;

namespace vopen_api.Migrations
{
    public partial class EditionsActivityDateTrackAndTags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Day",
                table: "EditionsActivities",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tags",
                table: "EditionsActivities",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Track",
                table: "EditionsActivities",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Day",
                table: "EditionsActivities");

            migrationBuilder.DropColumn(
                name: "Tags",
                table: "EditionsActivities");

            migrationBuilder.DropColumn(
                name: "Track",
                table: "EditionsActivities");
        }
    }
}
