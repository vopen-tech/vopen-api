using System.Collections.Generic;

namespace vopen_api.Models
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string Language { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<UserSocialLinkDTO> SocialLinks { get; set; }
    }

    public class UserSocialLinkDTO
    {
        public string Type { get; set; }
        public string Url { get; set; }
    }
}
