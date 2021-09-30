using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vopen_api.Data
{
    [Table("Events")]
    public class Event // e.g vOpen AR
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        public ICollection<EventDetail> Details { get; set; }
    }

    [Table("EventsDetails")]
    public class EventDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        public Event Event { get; set; }

        [Required]
        public string Language { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
