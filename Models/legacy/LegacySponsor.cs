using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vopen_api.Models.legacy
{
    public class LegacySponsor
    {
        public string SponsorId { get; set; }
        public long GlobalRanking { get; set; }
        public string Name { get; set; }
        public string LogoFileName { get; set; }
        public string WebSite { get; set; }
    }
}
