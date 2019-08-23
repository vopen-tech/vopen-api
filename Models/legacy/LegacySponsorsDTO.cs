using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vopen_api.Models.legacy
{
    public class LegacySponsorsDTO
    {
        public string imageBaseURL { get; set; }
        public string info { get; set; }
        public IList<LegacySponsor> sponsors { get; set; }
    }
}
