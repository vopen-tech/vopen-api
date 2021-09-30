﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace vopen_api.Migrations
{
    public partial class InitialSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sponsors",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sponsors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Editions",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    EventId = table.Column<string>(nullable: false),
                    LocationName = table.Column<string>(nullable: true),
                    LocationFullAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Editions_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventsDetails",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    EventId = table.Column<string>(nullable: false),
                    Language = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventsDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventsDetails_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersDetails",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    Language = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    JobTitle = table.Column<string>(nullable: true),
                    Company = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersDetails_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersProposals",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersProposals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersProposals_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersSocialLinks",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    Url = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersSocialLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersSocialLinks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EditionsActivities",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    EditionId = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    Day = table.Column<string>(nullable: false),
                    Track = table.Column<string>(nullable: false),
                    Date = table.Column<string>(nullable: false),
                    Duration = table.Column<string>(nullable: false),
                    Tags = table.Column<string>(nullable: true),
                    Level = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EditionsActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EditionsActivities_Editions_EditionId",
                        column: x => x.EditionId,
                        principalTable: "Editions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EditionsDetails",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    EditionId = table.Column<string>(nullable: false),
                    Language = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Date = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EditionsDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EditionsDetails_Editions_EditionId",
                        column: x => x.EditionId,
                        principalTable: "Editions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EditionsOrganizers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    EditionId = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EditionsOrganizers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EditionsOrganizers_Editions_EditionId",
                        column: x => x.EditionId,
                        principalTable: "Editions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EditionsOrganizers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EditionsSponsors",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    EditionId = table.Column<string>(nullable: false),
                    SponsorId = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EditionsSponsors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EditionsSponsors_Editions_EditionId",
                        column: x => x.EditionId,
                        principalTable: "Editions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EditionsSponsors_Sponsors_SponsorId",
                        column: x => x.SponsorId,
                        principalTable: "Sponsors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "UsersProposalsDetails",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserProposalId = table.Column<string>(nullable: false),
                    Language = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersProposalsDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersProposalsDetails_UsersProposals_UserProposalId",
                        column: x => x.UserProposalId,
                        principalTable: "UsersProposals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EditionsActivitiesDetails",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    EditionActivityId = table.Column<string>(nullable: false),
                    Language = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EditionsActivitiesDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EditionsActivitiesDetails_EditionsActivities_EditionActivityId",
                        column: x => x.EditionActivityId,
                        principalTable: "EditionsActivities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EditionsActivitiesScores",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    EditionActivityId = table.Column<string>(nullable: false),
                    UserEmail = table.Column<string>(nullable: false),
                    Score = table.Column<double>(nullable: false),
                    Comments = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EditionsActivitiesScores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EditionsActivitiesScores_EditionsActivities_EditionActivityId",
                        column: x => x.EditionActivityId,
                        principalTable: "EditionsActivities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EditionsActivitiesUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    EditionActivityId = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EditionsActivitiesUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EditionsActivitiesUsers_EditionsActivities_EditionActivityId",
                        column: x => x.EditionActivityId,
                        principalTable: "EditionsActivities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EditionsActivitiesUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Editions_EventId",
                table: "Editions",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EditionsActivities_EditionId",
                table: "EditionsActivities",
                column: "EditionId");

            migrationBuilder.CreateIndex(
                name: "IX_EditionsActivitiesDetails_EditionActivityId",
                table: "EditionsActivitiesDetails",
                column: "EditionActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_EditionsActivitiesScores_EditionActivityId",
                table: "EditionsActivitiesScores",
                column: "EditionActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_EditionsActivitiesUsers_EditionActivityId",
                table: "EditionsActivitiesUsers",
                column: "EditionActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_EditionsActivitiesUsers_UserId",
                table: "EditionsActivitiesUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EditionsDetails_EditionId",
                table: "EditionsDetails",
                column: "EditionId");

            migrationBuilder.CreateIndex(
                name: "IX_EditionsOrganizers_EditionId",
                table: "EditionsOrganizers",
                column: "EditionId");

            migrationBuilder.CreateIndex(
                name: "IX_EditionsOrganizers_UserId",
                table: "EditionsOrganizers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EditionsSponsors_EditionId",
                table: "EditionsSponsors",
                column: "EditionId");

            migrationBuilder.CreateIndex(
                name: "IX_EditionsSponsors_SponsorId",
                table: "EditionsSponsors",
                column: "SponsorId");

            migrationBuilder.CreateIndex(
                name: "IX_EditionsTickets_EditionId",
                table: "EditionsTickets",
                column: "EditionId");

            migrationBuilder.CreateIndex(
                name: "IX_EventsDetails_EventId",
                table: "EventsDetails",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersDetails_UserId",
                table: "UsersDetails",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersProposals_UserId",
                table: "UsersProposals",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersProposalsDetails_UserProposalId",
                table: "UsersProposalsDetails",
                column: "UserProposalId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersSocialLinks_UserId",
                table: "UsersSocialLinks",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EditionsActivitiesDetails");

            migrationBuilder.DropTable(
                name: "EditionsActivitiesScores");

            migrationBuilder.DropTable(
                name: "EditionsActivitiesUsers");

            migrationBuilder.DropTable(
                name: "EditionsDetails");

            migrationBuilder.DropTable(
                name: "EditionsOrganizers");

            migrationBuilder.DropTable(
                name: "EditionsSponsors");

            migrationBuilder.DropTable(
                name: "EditionsTickets");

            migrationBuilder.DropTable(
                name: "EventsDetails");

            migrationBuilder.DropTable(
                name: "UsersDetails");

            migrationBuilder.DropTable(
                name: "UsersProposalsDetails");

            migrationBuilder.DropTable(
                name: "UsersSocialLinks");

            migrationBuilder.DropTable(
                name: "EditionsActivities");

            migrationBuilder.DropTable(
                name: "Sponsors");

            migrationBuilder.DropTable(
                name: "UsersProposals");

            migrationBuilder.DropTable(
                name: "Editions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
