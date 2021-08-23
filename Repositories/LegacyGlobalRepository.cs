using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using vopen_api.Models;
using vopen_api.Data;

namespace vopen_api.Repositories
{
    public class LegacyGlobalRepository
    {
        private IWebHostEnvironment hostingEnvironment;

        public LegacyGlobalRepository(IWebHostEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }

        public EditionDTO GetEdition(string id)
        {
            var speakers = this.GetSpeakers();
            var sponsors = this.GetSponsors();

            return new EditionDTO
            {
                Id = id,
                Name = "vOpen Global",
                Description = "Historical data",
                Sponsors = sponsors,
                Speakers = speakers,
            };
        }
            

        private ICollection<UserDTO> GetSpeakers()
        {
            var baseUrl = "https://vopentechstorage.blob.core.windows.net/images/speakers/";
            var sha = "sv=2018-03-28&ss=bfqt&srt=sco&sp=rl&st=2020-02-24T03%3A12%3A42Z&se=2030-02-25T03%3A12%3A00Z&sig=3OkoIhl2W3nc4bmTofW%2FqhMl7XhBXxp%2FxN7l51%2FNxM0%3D";
            using (StreamReader file = File.OpenText(Path.Combine(hostingEnvironment.WebRootPath, "speakers.json")))
            {
                string json = file.ReadToEnd();
                var items = JsonConvert.DeserializeObject<List<LegacySpeaker>>(json);
                return items.Select(item => new UserDTO
                {
                    Id = item.speakerId,
                    Country = item.countryId,
                    Name = item.fullName,
                    Company = item.company,
                    JobTitle = item.jobTitle,
                    ImageUrl = baseUrl + item.avatarFileName + ".jpg?" + sha,
                    SocialLinks = new List<UserSocialLinkDTO>()
                    {
                        new UserSocialLinkDTO() { Type = Constants.SOCIAL_TWITTER, Url = item.twitter },
                        new UserSocialLinkDTO() { Type = Constants.SOCIAL_LINKEDIN, Url = item.linkedIn },
                    }
                }).ToList();
            }
        }

        private ICollection<EditionSponsorDTO> GetSponsors()
        {
            var baseUrl = "https://vopentechstorage.blob.core.windows.net/images/sponsors/";
            var sha = "sv=2018-03-28&ss=bfqt&srt=sco&sp=rl&st=2020-02-24T03%3A12%3A42Z&se=2030-02-25T03%3A12%3A00Z&sig=3OkoIhl2W3nc4bmTofW%2FqhMl7XhBXxp%2FxN7l51%2FNxM0%3D";
            using (StreamReader file = File.OpenText(Path.Combine(hostingEnvironment.WebRootPath, "sponsors.json")))
            {
                string json = file.ReadToEnd();
                var items = JsonConvert.DeserializeObject<List<LegacySponsor>>(json);
                return items.Select(item => new EditionSponsorDTO
                {
                    Id = item.sponsorId,
                    Name = item.name,
                    Url = item.website,
                    ImageUrl = baseUrl + item.logoFileName + ".png?" + sha
                }).ToList();
            }
        }
    }

    public class LegacySpeaker
    {
        public string speakerId { get; set; }
        public string countryId { get; set; }
        public string fullName { get; set; }
        public string jobTitle { get; set; }
        public string company { get; set; }
        public string twitter { get; set; }
        public string linkedIn { get; set; }
        public string avatarFileName { get; set; }
    }

    public class LegacySponsor
    {
        public string sponsorId { get; set; }
        public string globalRanking { get; set; }
        public string name { get; set; }
        public string logoFileName { get; set; }
        public string website { get; set; }
    }
}
