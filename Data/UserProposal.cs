using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vopen_api.Data
{
    [Table("UsersProposals")]
    public class UserProposal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        public ICollection<UserProposalDetails> Details { get; set; }

        [Required]
        [ForeignKey("UserId")]
        public User User { get; set; }

        [Required]
        public string Type { get; set; }
    }

    [Table("UsersProposalsDetails")]
    public class UserProposalDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        public UserProposal UserProposal { get; set; }

        [Required]
        public string Language { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }
    }
}
