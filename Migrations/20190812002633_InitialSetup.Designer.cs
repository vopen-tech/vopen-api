﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using vopen_api.Data;

namespace vopen_api.Migrations
{
    [DbContext(typeof(VOpenDbContext))]
    [Migration("20190812002633_InitialSetup")]
    partial class InitialSetup
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("vopen_api.Data.Edition", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EventId")
                        .IsRequired();

                    b.Property<string>("LocationFullAddress");

                    b.Property<string>("LocationName");

                    b.Property<string>("TicketPrice");

                    b.Property<string>("TicketSaleEndDate");

                    b.Property<string>("TicketSaleStartDate");

                    b.Property<string>("TicketType");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Editions");
                });

            modelBuilder.Entity("vopen_api.Data.EditionActivity", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Date")
                        .IsRequired();

                    b.Property<string>("Duration")
                        .IsRequired();

                    b.Property<string>("EditionId")
                        .IsRequired();

                    b.Property<string>("Type")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("EditionId");

                    b.ToTable("EditionsActivities");
                });

            modelBuilder.Entity("vopen_api.Data.EditionActivityDetail", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("EditionActivityId")
                        .IsRequired();

                    b.Property<string>("Language")
                        .IsRequired();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("EditionActivityId");

                    b.ToTable("EditionsActivitiesDetails");
                });

            modelBuilder.Entity("vopen_api.Data.EditionActivityPresenter", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EditionsActivityId")
                        .IsRequired();

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("EditionsActivityId");

                    b.HasIndex("UserId");

                    b.ToTable("EditionsActivitiesPresenters");
                });

            modelBuilder.Entity("vopen_api.Data.EditionActivityScore", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comments");

                    b.Property<string>("EditionActivityId")
                        .IsRequired();

                    b.Property<int>("Score");

                    b.HasKey("Id");

                    b.HasIndex("EditionActivityId");

                    b.ToTable("EditionsActivitiesScores");
                });

            modelBuilder.Entity("vopen_api.Data.EditionDetail", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Date");

                    b.Property<string>("Description");

                    b.Property<string>("EditionId")
                        .IsRequired();

                    b.Property<string>("Language")
                        .IsRequired();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("EditionId");

                    b.ToTable("EditionsDetails");
                });

            modelBuilder.Entity("vopen_api.Data.EditionOrganizer", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EditionId")
                        .IsRequired();

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("EditionId");

                    b.HasIndex("UserId");

                    b.ToTable("EditionsOrganizers");
                });

            modelBuilder.Entity("vopen_api.Data.EditionSponsor", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EditionId")
                        .IsRequired();

                    b.Property<string>("SponsorId")
                        .IsRequired();

                    b.Property<string>("Type")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("EditionId");

                    b.HasIndex("SponsorId");

                    b.ToTable("EditionsSponsors");
                });

            modelBuilder.Entity("vopen_api.Data.Event", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("vopen_api.Data.EventDetail", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("EventId")
                        .IsRequired();

                    b.Property<string>("Language")
                        .IsRequired();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("EventsDetails");
                });

            modelBuilder.Entity("vopen_api.Data.Sponsor", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("Sponsors");
                });

            modelBuilder.Entity("vopen_api.Data.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Country");

                    b.Property<string>("EditionActivityId");

                    b.Property<string>("ImageUrl");

                    b.HasKey("Id");

                    b.HasIndex("EditionActivityId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("vopen_api.Data.UserDetail", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Language")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UsersDetails");
                });

            modelBuilder.Entity("vopen_api.Data.UserProposal", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Type")
                        .IsRequired();

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UsersProposals");
                });

            modelBuilder.Entity("vopen_api.Data.UserProposalDetails", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Language")
                        .IsRequired();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<string>("UserProposalId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserProposalId");

                    b.ToTable("UsersProposalsDetails");
                });

            modelBuilder.Entity("vopen_api.Data.UserSocialLink", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Type")
                        .IsRequired();

                    b.Property<string>("Url")
                        .IsRequired();

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UsersSocialLinks");
                });

            modelBuilder.Entity("vopen_api.Data.Edition", b =>
                {
                    b.HasOne("vopen_api.Data.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("vopen_api.Data.EditionActivity", b =>
                {
                    b.HasOne("vopen_api.Data.Edition", "Edition")
                        .WithMany("Activities")
                        .HasForeignKey("EditionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("vopen_api.Data.EditionActivityDetail", b =>
                {
                    b.HasOne("vopen_api.Data.EditionActivity", "EditionActivity")
                        .WithMany("Details")
                        .HasForeignKey("EditionActivityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("vopen_api.Data.EditionActivityPresenter", b =>
                {
                    b.HasOne("vopen_api.Data.EditionActivity", "EditionActivity")
                        .WithMany()
                        .HasForeignKey("EditionsActivityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("vopen_api.Data.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("vopen_api.Data.EditionActivityScore", b =>
                {
                    b.HasOne("vopen_api.Data.EditionActivity", "EditionActivity")
                        .WithMany("Scores")
                        .HasForeignKey("EditionActivityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("vopen_api.Data.EditionDetail", b =>
                {
                    b.HasOne("vopen_api.Data.Edition", "Edition")
                        .WithMany("Details")
                        .HasForeignKey("EditionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("vopen_api.Data.EditionOrganizer", b =>
                {
                    b.HasOne("vopen_api.Data.Edition", "Edition")
                        .WithMany("Organizers")
                        .HasForeignKey("EditionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("vopen_api.Data.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("vopen_api.Data.EditionSponsor", b =>
                {
                    b.HasOne("vopen_api.Data.Edition", "Edition")
                        .WithMany("Sponsors")
                        .HasForeignKey("EditionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("vopen_api.Data.Sponsor", "Sponsor")
                        .WithMany()
                        .HasForeignKey("SponsorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("vopen_api.Data.EventDetail", b =>
                {
                    b.HasOne("vopen_api.Data.Event", "Event")
                        .WithMany("Details")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("vopen_api.Data.User", b =>
                {
                    b.HasOne("vopen_api.Data.EditionActivity")
                        .WithMany("Presenters")
                        .HasForeignKey("EditionActivityId");
                });

            modelBuilder.Entity("vopen_api.Data.UserDetail", b =>
                {
                    b.HasOne("vopen_api.Data.User", "User")
                        .WithMany("Details")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("vopen_api.Data.UserProposal", b =>
                {
                    b.HasOne("vopen_api.Data.User", "User")
                        .WithMany("Proposals")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("vopen_api.Data.UserProposalDetails", b =>
                {
                    b.HasOne("vopen_api.Data.UserProposal", "UserProposal")
                        .WithMany("Details")
                        .HasForeignKey("UserProposalId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("vopen_api.Data.UserSocialLink", b =>
                {
                    b.HasOne("vopen_api.Data.User", "User")
                        .WithMany("SocialLinks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
