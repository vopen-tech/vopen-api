using System;
using System.Collections.Generic;

namespace vopen_api.Models
{
    public class Organizer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<SocialLink> SocialLinks { get; set; }
    }

    public class SocialLink
    {
        public string Type { get; set; }
        public string Url { get; set; }
    }
}
