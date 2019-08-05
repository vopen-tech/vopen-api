using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vopen_api.Data
{
    [Table("ActivitiesScores")]
    public class ActivityScore
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        public EditionActivity EditionActivity { get; set; }

        [Required]
        public int Score { get; set; }

        public string Comments { get; set; }
    }
}
