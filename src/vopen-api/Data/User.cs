using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using vopen_api.Models;

namespace vopen_api.Data
{
    [Table("Users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public string ImageUrl { get; set; }

        public string Country { get; set; }

        [Required]
        public ICollection<UserDetail> Details { get; set; } = new List<UserDetail>();

        [Required]
        public ICollection<UserSocialLink> SocialLinks { get; set; } = new List<UserSocialLink>();

        [Required]
        public ICollection<UserProposal> Proposals { get; set; } = new List<UserProposal>();
    }

    [Table("UsersDetails")]
    public class UserDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        [ForeignKey("UserId")]
        public User User { get; set; }

        [Required]
        public string Language { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public string JobTitle { get; set; }

        public string Company { get; set; }
    }

    [Table("UsersSocialLinks")]
    public class UserSocialLink
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        [ForeignKey("UserId")]
        public User User { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Url { get; set; }
    }
}
