using System.Collections.Generic;

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
}
