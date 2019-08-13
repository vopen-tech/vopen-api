using System.Collections.Generic;

namespace vopen_api.Models.legacy
{
    public class LegacyConfSponsorsDTO
    {
        public string imageBaseURL { get; set; }
        public string info { get; set; }
        public IList<ConfSponsors> confSponsors { get; set; }
    }

    public class ConfSponsors {
        public int SponsorId { get; set; }
        public LegacySponsor Sponsor { get; set; }
        public int SponsorCategoryId { get; set; }
        public IList<SponsorCategory> SponsorCategory { get;set;}
        public bool HasBooth { get; set; }

    }

    public class SponsorCategory {
        public int SponsorCategoryId { get; set; }
        public string Name { get; set; }
        public string HexColor { get; set; }
    }
}
