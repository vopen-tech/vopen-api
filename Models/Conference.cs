using System;
using System.Collections.Generic;

namespace vopen_api.Models
{
    public class Conference
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Edition> Editions { get; set; }
    }
}
