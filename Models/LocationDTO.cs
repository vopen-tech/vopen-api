using System.Linq;
using vopen_api.Data;

namespace vopen_api.Models
{
    public class LocationDTO
    {
        public string Id { get; set; }

        public string Language { get; set; }

        public string Name { get; set; }

        public string FullAddress { get; set; }

        public string Country { get; set; }
    }

    public static class LocationUtils
    {
        public static LocationDTO ToLocationDTO(Location location, string language)
        {
            var details = location.Details.FirstOrDefault(item => item.Language == language);

            return new LocationDTO
            {
                Language = language,
                Name = details.Name,
                FullAddress = details.FullAddress,
                Country = details.Country
            };
        }
    }
}
