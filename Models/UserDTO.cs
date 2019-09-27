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
        public string JobTitle { get; set; }
        public string Company { get; set; }
        public string Description { get; set; }
        public ICollection<UserSocialLinkDTO> SocialLinks { get; set; }
    }

    public class UserSocialLinkDTO
    {
        public string Type { get; set; }
        public string Url { get; set; }
    }

    public static class UserUtils
    {
        public static UserDTO ToUserDTO(User user, string language)
        {
            var userDetail = user.Details.FirstOrDefault(item => item.Language == language) ?? user.Details.First();

            return new UserDTO
            {
                Id = userDetail.Id,
                Language = language,
                Country = user.Country,
                ImageUrl = user.ImageUrl,
                Name = userDetail.Name,
                Description = userDetail.Description,
                JobTitle = userDetail.JobTitle,
                Company = userDetail.Company,
                SocialLinks = user.SocialLinks.Select(c => new UserSocialLinkDTO { Type = c.Type, Url = c.Url }).ToList()
            };
        }

        public static ICollection<UserDTO> ToUsersDTO(IEnumerable<EditionActivityUser> editionActivityUsers, string language)
        {
            if (editionActivityUsers == null)
            {
                return new List<UserDTO>();
            }

            return editionActivityUsers.Select(editionActivityUser => UserUtils.ToUserDTO(editionActivityUser.User, language)).ToList();
        }

        public static ICollection<UserDTO> ToUsersDTO(IEnumerable<User> users, string language)
        {
            if (users == null)
            {
                return new List<UserDTO>();
            }

            return users.Select(user => UserUtils.ToUserDTO(user, language)).ToList();
        }
    }
}
