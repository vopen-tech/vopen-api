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
        public ICollection<EditionDetail> Details { get; set; }

        [Required]
        public Event Event { get; set; }

        public Location Location { get; set; }

        public EditionTicketInfo TicketInfo { get; set; }

        [Required]
        public ICollection<EditionOrganizer> Organizers { get; set; }

        [Required]
        public ICollection<EditionSponsor> Sponsors { get; set; }

        [Required]
        public ICollection<EditionActivity> Activities { get; set; }
    }

    [Table("EditionsDetails")]
    public class EditionDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        public Edition Edition { get; set; }

        [Required]
        public string Language { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Date { get; set; }
    }

    [Table("EditionsTicketInfos")]
    public class EditionTicketInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        public Edition Edition { get; set; }

        [Required]
        public string Type { get; set; }

        public string Price { get; set; }

        public string TicketSaleStartDate { get; set; }

        public string TicketSaleEndDate { get; set; }
    }

    [Table("EditionsOrganizers")]
    public class EditionOrganizer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
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
        public Edition Edition { get; set; }

        [Required]
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
        public Edition Edition { get; set; }

        [Required]
        public Activity Activity { get; set; }

        [Required]
        public ICollection<User> Presenters { get; set; }

        [Required]
        public string Date { get; set; }

        [Required]
        public string Duration { get; set; }
    }
}
