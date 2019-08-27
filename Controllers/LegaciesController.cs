using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using vopen_api.Models.legacy;
using vopen_api.Repositories;

namespace vopen_api.Controllers
{
    [Route("legacy/api/v1")]
    [ApiController]
    public class LegaciesController : ControllerBase
    {
        private readonly EditionsRepository editionsRepository;
        private readonly IConfiguration configuration;
        private readonly string mobileAppUser = "app";
        private readonly string mobileAppToken = "66197FD1-6C77-4D20-A10D-D27BF2B7D053";

        public LegaciesController(EditionsRepository editionsRepository, IConfiguration configuration)
        {
            this.editionsRepository = editionsRepository;
            this.configuration = configuration;

            var configurationMobileApp = configuration.GetSection("MobileApp");
            this.mobileAppUser = configurationMobileApp.GetSection("User").Value;
            this.mobileAppToken = configurationMobileApp.GetSection("Token").Value;
        }

        [HttpPost("editions")]
        public async Task<IActionResult> Editions()
        {
            var language = this.GetLanguage();
            var editions = await this.editionsRepository.GetAllByLanguage(language);
            var editionIds = editions.Select(c => c.Id);

            return Ok(editionIds);
        }

        [HttpPost("{editionId}/appconfig")]
        public IActionResult AppConfig()
        {
            return this.NoContent();
        }

        [HttpPost("{editionId}/sponsors")]
        public async Task<IActionResult> Sponsors(string editionId, LegacyRequestBody body)
        {
            if (!this.IsValidRequest(body))
            {
                return Unauthorized();
            }

            var language = this.GetLanguage();
            var edition = await this.editionsRepository.GetByLanguageAndId(language, editionId);
            var legacySponsors = LegacySponsorsUtils.ToLegacySponsorsDTO(edition.Sponsors);

            return Ok(legacySponsors);
        }

        [HttpPost("{editionId}/confSponsors")]
        public async Task<IActionResult> ConfSponsors(string editionId)
        {
            var language = this.GetLanguage();
            var edition = await this.editionsRepository.GetByLanguageAndId(language, editionId);
            var legacyConfSponsors = LegacyConfSponsorsUtils.ToLegacyConfSponsorsDTO(edition.Sponsors);

            return Ok(legacyConfSponsors);
        }

        [HttpPost("IsValidAttendee")]
        public async Task<IActionResult> IsValidAttendee(LegacyIsValidAttendeeRequestBody attendeeBody)
        {
            if (!this.IsValidRequest(attendeeBody))
            {
                return Unauthorized();
            }

            LegacyEventbriteAttendeesResponse.Attendee result = null;

            var configurationEventBrite = configuration.GetSection("EventBrite");
            var eventBriteId = configurationEventBrite.GetSection("EventbriteEventId").Value;
            var eventBriteUSer = configurationEventBrite.GetSection("User").Value;
            var eventBriteKey = configurationEventBrite.GetSection("Key").Value;
            var eventBriteClientSecret = configurationEventBrite.GetSection("ClientSecret").Value;
            var eventBriteOAuthTokenPersonal = configurationEventBrite.GetSection("OAuthTokenPersonal").Value;
            var eventBriteOAuthTokenAnonymous = configurationEventBrite.GetSection("OAuthTokenAnonymous").Value;
            var eventBriteAttendeesAddress = configurationEventBrite.GetSection("AttendeesAddress").Value + "attendees/?token=" + eventBriteOAuthTokenPersonal;
            var eventbriteTicketNamesAllowedInRaffle = configurationEventBrite.GetSection("EventbriteTicketNamesAllowedInRaffle").Value;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            var attendeesRawResponse = "";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(eventBriteAttendeesAddress);
            request.Accept = "application/json";

            try
            {
                using (WebResponse response = await request.GetResponseAsync())
                using (Stream dataStream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(dataStream))
                {
                    attendeesRawResponse = reader.ReadToEnd();
                }

                var attendeesResponse = JsonConvert.DeserializeObject<LegacyEventbriteAttendeesResponse>(attendeesRawResponse);

                if (attendeesResponse != null && eventbriteTicketNamesAllowedInRaffle.ToLower().Contains(result.ticket_class_name.ToLower()) == false)
                {
                    // Found but ticket not allowed.
                    result = null;
                }
                else
                {
                    result = attendeesResponse.attendees.FirstOrDefault(a => a.profile.email.ToLowerInvariant() == attendeeBody.Email.ToLowerInvariant());
                }

                return Ok(result);
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }

        private bool IsValidRequest(LegacyRequestBody body)
        {
            if (body == null)
            {
                return false;
            }

            var isValidUser = body.User != null && body.User.ToLower() == this.mobileAppUser;
            var isValidToken = body.Token != null && body.Token.ToUpper() == this.mobileAppToken;
            return isValidUser && isValidToken;
        }

        private string GetLanguage()
        {
            if (Request.Headers["Accept-Language"].ToString() == "")
            {
                return "es-AR";
            }

            return Request.Headers["Accept-Language"].ToString().Split(',')[0];
        }
    }

    public class LegacyRequestBody
    {
        public string User { get; set; }
        public string Token { get; set; }
    }

    public class LegacyIsValidAttendeeRequestBody : LegacyRequestBody
    {
        public string Email { get; set; }
    }

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