using Microsoft.EntityFrameworkCore.Migrations;

namespace vopen_api.Migrations
{
    public partial class EditionsTickets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketPrice",
                table: "Editions");

            migrationBuilder.DropColumn(
                name: "TicketSaleEndDate",
                table: "Editions");

            migrationBuilder.DropColumn(
                name: "TicketSaleStartDate",
                table: "Editions");

            migrationBuilder.DropColumn(
                name: "TicketType",
                table: "Editions");

            migrationBuilder.CreateTable(
                name: "EditionsTickets",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    EditionId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<string>(nullable: true),
                    StartDate = table.Column<string>(nullable: true),
                    EndDate = table.Column<string>(nullable: true),
                    BuyLinks = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EditionsTickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EditionsTickets_Editions_EditionId",
                        column: x => x.EditionId,
                        principalTable: "Editions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EditionsTickets_EditionId",
                table: "EditionsTickets",
                column: "EditionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EditionsTickets");

            migrationBuilder.AddColumn<string>(
                name: "TicketPrice",
                table: "Editions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TicketSaleEndDate",
                table: "Editions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TicketSaleStartDate",
                table: "Editions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TicketType",
                table: "Editions",
                nullable: true);
        }
    }
}
