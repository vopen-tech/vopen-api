using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using vopen_api.Models.legacy;
using vopen_api.Repositories;

namespace vopen_api.Controllers
{
    [Route("legacy/api/v1/{edition}")]
    [ApiController]
    public class LegaciesController : ControllerBase
    {

        private readonly EditionsRepository editionsRepository;
        private readonly IConfiguration configuration;
        private readonly string country;
        
        public LegaciesController(EditionsRepository editionsRepository, IConfiguration configuration)
        {
            this.editionsRepository = editionsRepository;
            this.configuration = configuration;
            this.country = configuration.GetSection("Country").Value;
        }

        private void ValidateRequest(LegacyApiCredentialsDTO dto)
        {
            LegaciesController.ValidateAppRequest(dto.User, dto.Token);
        }
        
        internal static void ValidateAppRequest(string user, string token)
        {
            if (user.ToLower() != "app" || token.ToUpper() != "66197FD1-6C77-4D20-A10D-D27BF2B7D053")
            {
                throw new ApplicationException("Invalid credentials");
            }
        }

        //devuelve modelo LegacySpronsor
        [HttpPost("Sponsors")]
        public async Task<IActionResult> Sponsors(LegacyApiCredentialsDTO dto)
        {

            this.ValidateRequest(dto);

            var edition = await editionsRepository.GetByLanguageAndId("es", country);

            var result = new LegacySponsorsDTO();
            result.imageBaseURL = configuration.GetSection("SiteUrl").Value
                                            + "Content/images/demo/sponsor-logos/";
            result.info = "All images are .png";

            throw new NotImplementedException();
        }

        //devuelve modelo ConfSponsors
        [HttpPost("ConfSponsors")]
        public string ConfSponsors(LegacyApiCredentialsDTO dto)
        {
            this.ValidateRequest(dto);

            throw new NotImplementedException();
        }

        //devuelte integer
        [HttpPost("Editions")]
        public string Editions(LegacyApiCredentialsDTO dto)
        {
            this.ValidateRequest(dto);

            throw new NotImplementedException();
        }

        [HttpPost("AppConfig")]
        public string AppConfig(LegacyApiCredentialsDTO dto)
        {
            this.ValidateRequest(dto);

            throw new NotImplementedException();
        }

        //eventbrite
        [HttpPost("IsValidAttendee")]
        public string IsValidAttendee(LegacyApiCredentialsDTO dto)
        {
            this.ValidateRequest(dto);

            var edition = Convert.ToInt32(this.RouteData.Values["edition"].ToString());

            throw new NotImplementedException();
        }

    }
}