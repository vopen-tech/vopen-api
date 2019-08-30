using Microsoft.EntityFrameworkCore.Migrations;

namespace vopen_api.Migrations
{
    public partial class UsersCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Company",
                table: "UsersDetails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Company",
                table: "UsersDetails");
        }
    }
}
