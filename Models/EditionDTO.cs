using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
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
        public string LocationName { get; set; }
        public string LocationFullAddress { get; set; }

        public EventDTO Event { get; set; }

        public ICollection<EditionTicketDTO> EditionTickets { get; set; }

        public ICollection<UserDTO> Organizers { get; set; }

        public ICollection<EditionSponsorDTO> Sponsors { get; set; }

        public EditionActivitiesDTO Activities { get; set; }

        public ICollection<UserDTO> Speakers { get; set; }
    }

    public class EditionTicketDTO
    {
        public string Name { get; set; }

        public string Price { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public TicketLink[] BuyLinks { get; set; }
    }

    public class TicketLink
    {
        public string Label { get; set; }
        public string Url { get; set; }
    }

    public class EditionSponsorDTO
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string Url { get; set; }

        public string Type { get; set; }
    }

    public static class EditionUtils
    {
        public static EditionDTO ToEditionDTO(Edition edition, string language)
        {
            var details = edition.Details.FirstOrDefault(item => item.Language == language) ?? edition.Details.First();
            var activities = EditionActivityUtils.ToEditionActivitiesDTO(edition.Activities, language);
            var speakers = UserUtils.ToUsersDTO(edition.Activities.SelectMany(c => c.Users).Distinct().ToList(), language);

            return new EditionDTO
            {
                Id = edition.Id,
                Language = language,
                Name = details.Name,
                Description = details.Description,
                Date = details.Date,
                LocationName = edition.LocationName,
                LocationFullAddress = edition.LocationFullAddress,
                Event = EventUtils.ToEventDTO(edition.Event, language),
                Organizers = UserUtils.ToUsersDTO(edition.Organizers?.Select(item => item.User).ToList(), language),
                EditionTickets = EditionUtils.ToEditionTicketsDTO(edition.EditionTickets),
                Sponsors = EditionUtils.ToEditionSponsorsDTO(edition.Sponsors),
                Activities = activities,
                Speakers = speakers
            };
        }

        public static ICollection<EditionTicketDTO> ToEditionTicketsDTO(ICollection<EditionTicket> editionTickets)
        {
            if (editionTickets == null)
            {
                return new List<EditionTicketDTO>();
            }

            return editionTickets
                .Select(editionTicket => new EditionTicketDTO
                {
                    Name = editionTicket.Name,
                    Price = editionTicket.Price,
                    StartDate = editionTicket.StartDate,
                    EndDate = editionTicket.EndDate,
                    BuyLinks = editionTicket.BuyLinks != null ? JsonConvert.DeserializeObject<List<TicketLink>>(editionTicket.BuyLinks).ToArray() : null
                }
                ).ToList();
        }

        public static ICollection<EditionSponsorDTO> ToEditionSponsorsDTO(ICollection<EditionSponsor> editionSponsors)
        {
            if (editionSponsors == null)
            {
                return new List<EditionSponsorDTO>();
            }

            return editionSponsors
                .Select(editionSponsor => new EditionSponsorDTO
                {
                    Id = editionSponsor.Id,
                    Type = editionSponsor.Type,
                    Name = editionSponsor.Sponsor.Name,
                    Description = editionSponsor.Sponsor.Description,
                    Url = editionSponsor.Sponsor.Url,
                    ImageUrl = editionSponsor.Sponsor.ImageUrl
                }
                ).ToList();
        }
    }
}
