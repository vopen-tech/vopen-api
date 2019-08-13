using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vopen_api.Models.legacy
{
    public class LegacyAppConfigDTO
    {
        public int[] HighlightedSponsorsIds { get; set; }
        public IList<LegacySponsor> HighlightedSponsors { get; set; }
        public IList<Texts> Texts { get; set; }
    }

    public class Texts {
        public int LanguageId { get; set; }
        public string Key { get; set; }
        public string Text { get; set; }
    }
    
}
