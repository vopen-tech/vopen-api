using System;
using System.Collections.Generic;
using System.Linq;
using vopen_api.Data;

namespace vopen_api.Models
{
    public class EditionDTO
    {
        public string Id { get; set; }
        public string Language { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }

        public EventDTO Event { get; set; }

        public LocationDTO Location { get; set; }

        public EditionTicketInfoDTO TicketInfo { get; set; }

        public ICollection<UserDTO> Organizers { get; set; }

        public ICollection<EditionSponsorDTO> Sponsors { get; set; }

        public ICollection<EditionActivityDTO> Activities { get; set; }
    }

    public class EditionTicketInfoDTO
    {
        public string Type { get; set; }

        public string Price { get; set; }

        public string TicketSaleStartDate { get; set; }

        public string TicketSaleEndDate { get; set; }
    }

    public class EditionSponsorDTO
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public string Type { get; set; }
    }

    public class EditionActivityDTO
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public ICollection<UserDTO> Presenters { get; set; }

        public string Date { get; set; }

        public string Duration { get; set; }
    }

    public static class EditionUtils
    {
        public static EditionDTO ToEditionDTO(Edition edition, string language)
        {
            var languageDetails = edition.Details.FirstOrDefault(item => item.Language == language);

            return new EditionDTO
            {
                Id = edition.Id,
                Language = language,
                Name = languageDetails.Name,
                Description = languageDetails.Description,
                Date = languageDetails.Date,
                // TicketInfo = EditionUtils.ToEditionTicketInfoDTO(edition.TicketInfo),
                // Location = LocationUtils.ToLocationDTO(edition.Location),
                // Organizers = edition.Organizers != null ? edition.Organizers.Select(item => UserUtils.ToUserDTO(item)) : new List<UserDTO>(),
                // Sponsors = edition.Sponsors != null ? edition.Organizers.Select(item => EditionUtils.ToEditionSponsorDTO(item)) : new List<EditionSponsorDTO>(),
                // Activities = edition.Activities != null ? edition.Organizers.Select(item => EditionUtils.ToEditionActivityDTO(item)) : new List<EditionActivityDTO>(),
            };
        }

        public static Event FromEventDTO(EditionDTO eventDTO)
        {
            throw new NotImplementedException();
        }
    }
}
