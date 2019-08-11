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
        public string Name { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public string Type { get; set; }
    }

    public class EditionActivityDTO
    {
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
            var details = edition.Details.FirstOrDefault(item => item.Language == language);

            return new EditionDTO
            {
                Id = edition.Id,
                Language = language,
                Name = details.Name,
                Description = details.Description,
                Date = details.Date,
                TicketInfo = new EditionTicketInfoDTO { Type = edition.TicketInfo.Type, Price = edition.TicketInfo.Price, TicketSaleStartDate = edition.TicketInfo.TicketSaleStartDate, TicketSaleEndDate = edition.TicketInfo.TicketSaleEndDate },
                Location = LocationUtils.ToLocationDTO(edition.Location, language),
                Organizers = UserUtils.ToUsersDTO(edition.Organizers.Select(item => item.User).ToList(), language),
                Sponsors = edition.Sponsors != null ? edition.Sponsors.Select(item => EditionUtils.ToEditionSponsorDTO(item)).ToList() : new List<EditionSponsorDTO>(),
                Activities = edition.Activities != null ? edition.Activities.Select(item => EditionUtils.ToEditionActivityDTO(item, language)).ToList() : new List<EditionActivityDTO>(),
            };
        }

        public static EditionSponsorDTO ToEditionSponsorDTO(EditionSponsor editionSponsor)
        {
            return new EditionSponsorDTO
            {
                Type = editionSponsor.Type,
                Name = editionSponsor.Sponsor.Name,
                Description = editionSponsor.Sponsor.Description,
                Url = editionSponsor.Sponsor.Url
            };
        }

        public static EditionActivityDTO ToEditionActivityDTO(EditionActivity editionActivity, string language)
        {
            var details = editionActivity.Details.FirstOrDefault(item => item.Language == language);

            return new EditionActivityDTO
            {
                Date = editionActivity.Date,
                Presenters = UserUtils.ToUsersDTO(editionActivity.Presenters, language),
                Duration = editionActivity.Duration,
                Description = details.Description,
                Title = details.Title,
            };
        }

        public static Event FromEventDTO(EditionDTO eventDTO)
        {
            throw new NotImplementedException();
        }
    }
}
