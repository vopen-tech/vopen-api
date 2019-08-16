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
        public string LocationName { get; set; }
        public string LocationFullAddress { get; set; }
        public string TicketType { get; set; }
        public string TicketPrice { get; set; }
        public string TicketSaleStartDate { get; set; }
        public string TicketSaleEndDate { get; set; }

        public EventDTO Event { get; set; }

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

        public string ImageUrl { get; set; }

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
            var details = edition.Details.FirstOrDefault(item => item.Language == language) ?? edition.Details.First();

            return new EditionDTO
            {
                Id = edition.Id,
                Language = language,
                Name = details.Name,
                Description = details.Description,
                Date = details.Date,
                Event = EventUtils.ToEventDTO(edition.Event, language),
                LocationName = edition.LocationName,
                LocationFullAddress = edition.LocationFullAddress,
                TicketType = edition.TicketType,
                TicketPrice = edition.TicketPrice,
                TicketSaleStartDate = edition.TicketSaleStartDate,
                TicketSaleEndDate = edition.TicketSaleEndDate,
                Organizers = UserUtils.ToUsersDTO(edition.Organizers?.Select(item => item.User).ToList(), language),
                Sponsors = EditionUtils.ToEditionSponsorsDTO(edition.Sponsors),
                Activities = EditionUtils.ToEditionActivitiesDTO(edition.Activities, language),
            };
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

        public static ICollection<EditionActivityDTO> ToEditionActivitiesDTO(ICollection<EditionActivity> editionActivies, string language)
        {
            if (editionActivies == null)
            {
                return new List<EditionActivityDTO>();
            }

            return editionActivies.Select(editionActivity =>
                {
                    var details = editionActivity.Details.FirstOrDefault(item => item.Language == language) ?? editionActivity.Details.First();
                    return new EditionActivityDTO
                    {
                        Id = editionActivity.Id,
                        Date = editionActivity.Date,
                        Presenters = UserUtils.ToUsersDTO(editionActivity.Presenters, language),
                        Duration = editionActivity.Duration,
                        Description = details.Description,
                        Title = details.Title,
                    };

                }
            ).ToList();
        }
    }
}
 