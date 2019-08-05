using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vopen_api.Data
{
    [Table("Locations")]
    public class Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        public ICollection<LocationDetail> Details { get; set; }
    }

    [Table("LocationsDetails")]
    public class LocationDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        public Location Location { get; set; }

        [Required]
        public string Language { get; set; }

        public string Name { get; set; }

        public string FullAddress { get; set; }

        public string Country { get; set; }
    }
}
