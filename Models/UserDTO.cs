using System.Collections.Generic;
using System.Linq;
using vopen_api.Data;

namespace vopen_api.Models
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<UserSocialLink> SocialLinks { get; set; }
    }

    public static class UserUtils
    {
        public static UserDTO ToUserDTO(User user, string language)
        {
            var userDetail = user.Details.FirstOrDefault(item => item.Language == language);

            return new UserDTO
            {
                Id = userDetail.Id,
                Language = language,
                Country = user.Country,
                ImageUrl = user.ImageUrl,
                Name = userDetail.Name,
                Description = userDetail.Description,
                SocialLinks = user.SocialLinks
            };
        }

        public static User FromUserDTO(UserDTO userDTO)
        {
            var toReturn = new User()
            {
                Id = userDTO.Id,
                Country = userDTO.Country,
                ImageUrl = userDTO.ImageUrl,
                SocialLinks = userDTO.SocialLinks
            };

            toReturn.Details = new UserDetail[]
            {
                new UserDetail()
                {
                    Language = userDTO.Language,
                    Name = userDTO.Name,
                    Description = userDTO.Description
                }
            };

            return toReturn;
        }
    }
}
