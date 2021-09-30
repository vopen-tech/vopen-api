using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vopen_api.Data
{
    [Table("Editions")]
    public class Edition // e.g vOpen AR 2019 (being vOpen the Event)
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        public ICollection<EditionDetail> Details { get; set; } = new List<EditionDetail>();

        [Required]
        public Event Event { get; set; }

        public string LocationName { get; set; }

        public string LocationFullAddress { get; set; }

        public ICollection<EditionTicket> EditionTickets { get; set; } = new List<EditionTicket>();

        [Required]
        public ICollection<EditionOrganizer> Organizers { get; set; } = new List<EditionOrganizer>();

        [Required]
        public ICollection<EditionSponsor> Sponsors { get; set; } = new List<EditionSponsor>();

        [Required]
        public ICollection<EditionActivity> Activities { get; set; } = new List<EditionActivity>();
    }

    [Table("EditionsDetails")]
    public class EditionDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        [ForeignKey("EditionId")]
        public Edition Edition { get; set; }

        [Required]
        public string Language { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Date { get; set; }
    }

    [Table("EditionsTickets")]
    public class EditionTicket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        [ForeignKey("EditionId")]
        public Edition Edition { get; set; }

        [Required]
        public string Name { get; set; }

        public string Price { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public string BuyLinks { get; set; }
    }

    [Table("EditionsOrganizers")]
    public class EditionOrganizer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        [ForeignKey("EditionId")]
        public Edition Edition { get; set; }

        [Required]
        public User User { get; set; }
    }

    [Table("EditionsSponsors")]
    public class EditionSponsor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        [ForeignKey("EditionId")]
        public Edition Edition { get; set; }

        [Required]
        [ForeignKey("SponsorId")]
        public Sponsor Sponsor { get; set; }

        [Required]
        public string Type { get; set; }
    }

    [Table("EditionsActivities")]
    public class EditionActivity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        [ForeignKey("EditionId")]
        public Edition Edition { get; set; }

        [Required]
        public ICollection<EditionActivityDetail> Details { get; set; } = new List<EditionActivityDetail>();
        
        [Required]
        public ICollection<EditionActivityUser> Users { get; set; } = new List<EditionActivityUser>();

        [Required]
        public ICollection<EditionActivityScore> Scores { get; set; } = new List<EditionActivityScore>();

        [Required]
        public string Type { get; set; }

        [Required]
        public string Day { get; set; }

        [Required]
        public string Track { get; set; }

        [Required]
        public string Date { get; set; }

        [Required]
        public string Duration { get; set; }

        public string Tags { get; set; }

        public string Level { get; set; }
    }

    [Table("EditionsActivitiesDetails")]
    public class EditionActivityDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        [ForeignKey("EditionActivityId")]
        public EditionActivity EditionActivity { get; set; }

        [Required]
        public string Language { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }
    }

    [Table("EditionsActivitiesUsers")]
    public class EditionActivityUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        [ForeignKey("EditionActivityId")]
        public EditionActivity EditionActivity { get; set; }

        [Required]
        [ForeignKey("UserId")]
        public User User { get; set; }
    }

    [Table("EditionsActivitiesScores")]
    public class EditionActivityScore
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        [ForeignKey("EditionActivityId")]
        public EditionActivity EditionActivity { get; set; }

        [Required]
        public string UserEmail { get; set; }

        [Required]
        public double Score { get; set; }

        public string Comments { get; set; }
    }
}
