using Microsoft.EntityFrameworkCore;
using vopen_api.Models;

namespace vopen_api.Data
{
    public class VOpenDbContext : DbContext
    {
        public VOpenDbContext(DbContextOptions<VOpenDbContext> options) : base(options)
        {
        }

        public DbSet<Activity> Activities { get; set; }

        public DbSet<ActivityDetail> ActivitiesDetails { get; set; }

        public DbSet<ActivityScore> ActivitiesScores { get; set; }

        public DbSet<Edition> Editions { get; set; }

        public DbSet<EditionDetail> EditionsDetails { get; set; }

        public DbSet<EditionTicketInfo> EditionTicketInfos { get; set; }

        public DbSet<EditionOrganizer> EditionOrganizers { get; set; }

        public DbSet<EditionSponsor> EditionSponsors { get; set; }

        public DbSet<EditionActivity> EditionsActivities { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<EventDetail> EventsDetails { get; set; }

        public DbSet<Location> Location { get; set; }

        public DbSet<LocationDetail> LocationsDetails { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserDetail> UsersDetails { get; set; }

        public DbSet<UserSocialLink> UsersSocialLinks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Custom configurations not supported by DataAnnotations
            modelBuilder.Entity<ActivityDetail>().HasIndex(item => new { item.Activity.Id, item.Language }).IsUnique();
            modelBuilder.Entity<EditionDetail>().HasIndex(item => new { item.Edition.Id, item.Language }).IsUnique();
            modelBuilder.Entity<EventDetail>().HasIndex(item => new { item.Event.Id, item.Language }).IsUnique();
            modelBuilder.Entity<LocationDetail>().HasIndex(item => new { item.Location.Id, item.Language }).IsUnique();
            modelBuilder.Entity<UserDetail>().HasIndex(item => new { item.User.Id, item.Language }).IsUnique();
        }
    }
}
