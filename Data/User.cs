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

        [Required]
        public ICollection<UserDetail> Details { get; set; }

        public ICollection<UserSocialLink> SocialLinks { get; set; }
    }

    [Table("UsersDetails")]
    public class UserDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        public string Language { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }

    [Table("UsersSocialLinks")]
    public class UserSocialLink
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Url { get; set; }
    }
}
