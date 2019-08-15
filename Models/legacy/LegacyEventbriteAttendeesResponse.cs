using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vopen_api.Models.legacy
{
    public class LegacyEventbriteAttendeesResponse
    {
        public Pagination pagination { get; set; }
        public List<Attendee> attendees { get; set; }

        public class Attendee
        {
            public string ticket_class_name { get; set; }
            public Profile profile { get; set; }
            public class Profile
            {
                public string first_name { get; set; }
                public string last_name { get; set; }
                public string email { get; set; }
            }
        }

        public class Pagination
        {
            public string continuation { get; set; }
            public bool has_more_items { get; set; }
        }
    }
}