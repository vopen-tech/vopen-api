using System.Linq;
using vopen_api.Data;

namespace vopen_api.Models
{
    public class EventDTO
    {
        public string Id { get; set; }
        public string Language { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public static class EventUtils
    {
        public static EventDTO ToEventDTO(Event evt, string language)
        {
            var languageDetails = evt.Details.FirstOrDefault(item => item.Language == language) ?? evt.Details.First();

            return new EventDTO
            {
                Id = evt.Id,
                Language = language,
                Name = languageDetails.Name,
                Description = languageDetails.Description
            };
        }

        public static Event FromEventDTO(EventDTO eventDTO)
        {
            var toReturn = new Event() { Id = eventDTO.Id };
            toReturn.Details = new EventDetail[]
            {
                new EventDetail()
                {
                    Language = eventDTO.Language,
                    Name = eventDTO.Name,
                    Description = eventDTO.Description
                }
            };

            return toReturn;
        }
    }
}
