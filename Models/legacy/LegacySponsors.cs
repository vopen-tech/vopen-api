using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace vopen_api.Models.legacy
{
    public class LegacySponsorsDTO
    {
        public readonly string ImageBaseURL = "";
        public readonly string Info = "All images are .png";
        public ICollection<LegacySponsorDTO> Sponsors { get; set; }
    }

    public class LegacySponsorDTO
    {
        [JsonProperty("SponsorId")]
        public string SponsorId { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("LogoFileName")]
        public string LogoFileName { get; set; }

        [JsonProperty("WebSite")]
        public string Website { get; set; }

        public LegacySponsorDTO(EditionSponsorDTO sponsor)
        {
            this.SponsorId = sponsor.Id;
            this.Name = sponsor.Name;
            this.LogoFileName = sponsor.ImageUrl;
            this.Website = sponsor.Url;
        }
    }

    public static class LegacySponsorsUtils
    {
        public static LegacySponsorsDTO ToLegacySponsorsDTO(ICollection<EditionSponsorDTO> sponsors)
        {
            var legacySponsorDTO = new LegacySponsorsDTO
            {
                Sponsors = sponsors.Select(sponsor => new LegacySponsorDTO(sponsor)).ToList()
            };

            return legacySponsorDTO;
        }
    }
}
