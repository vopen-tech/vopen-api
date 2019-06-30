using System;
using System.Collections.Generic;

namespace vopen_api.Models
{
    public class Edition
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Location Location { get; set; }
        public string Date { get; set; }
        public TicketsInfo TicketsInfo { get; set; }
        public ICollection<Organizer> organizers { get; set; }
    }

    public class Location
    {
        public string FullAddress { get; set; }
        public string VenueName { get; set; }
        public string Description { get; set; }
    }

    public class TicketsInfo
    {
        public string TicketsType { get; set; }
        public bool IsTicketSaleOpen { get; set; }
    }
}
