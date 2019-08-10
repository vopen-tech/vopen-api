using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vopen_api.Repositories;

namespace vopen_api.Controllers
{
    [Route("legacy/api/v1/{edition}")]
    [ApiController]
    public class LegaciesController : ControllerBase
    {

        private readonly EditionsRepository editionsRepository;
        private readonly int edition;

        public LegaciesController(EditionsRepository editionsRepository)
        {
            this.editionsRepository = editionsRepository;
            this.edition = Convert.ToInt32(this.RouteData.Values["edition"].ToString());
        }


        //devuelve modelo LegacySpronsor
        [HttpPost("Sponsors")]
        public string Sponsors()
        {
            throw new NotImplementedException();
        }

        //devuelve modelo LegacySpronsor
        [HttpPost("ConfSponsors")]
        public string ConfSponsors()
        {
            throw new NotImplementedException();
        }

        //devuelte integer
        [HttpPost("Editions")]
        public string Editions()
        {
            throw new NotImplementedException();
        }

        [HttpPost("AppConfig")]
        public string AppConfig()
        {
            throw new NotImplementedException();
        }

        //eventbrite
        [HttpPost("IsValidAttendee")]
        public string IsValidAttendee()
        {
            throw new NotImplementedException();
        }

    }
}