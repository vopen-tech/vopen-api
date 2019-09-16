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

        [HttpPost("{editionId}/confSponsors")]
        public async Task<IActionResult> ConfSponsors(string editionId, LegacyRequestBody body)
        {
            if (!this.IsValidRequest(body))
            {
                return Unauthorized();
            }

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

            try
            {
                var configurationEventbrite = configuration.GetSection("Eventbrite");
                var ticketNamesAllowedInRaffle = configurationEventbrite.GetSection("TicketNamesAllowedInRaffle").Value;

                var result = new LegacyIsValidAttendeeResponseBody { Email = attendeeBody.Email, IsValid = false };
                bool attendeeFound = false;
                bool hasMorePages = true;
                int page = 1;

                while(!attendeeFound && hasMorePages)
                {
                    var response = await this.GetAttendeesInEvent(attendeeBody.EventId, page);
                    var attendee = response.attendees
                        .FirstOrDefault(item =>
                          item.Profile.Email.ToLowerInvariant() == attendeeBody.Email.ToLowerInvariant()
                          && ticketNamesAllowedInRaffle.ToLower().Contains(item.TicketClassName.ToLowerInvariant())
                        );

                    attendeeFound = attendee != null;
                    hasMorePages = response.Pagination.HasMoreItems;
                    page += 1;
                }
               
                result.IsValid = attendeeFound;
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        private async Task<LegacyEventbriteAttendeesResponse> GetAttendeesInEvent(string eventId, int page = 1)
        {

            var configurationEventbrite = configuration.GetSection("Eventbrite");
            var eventbriteEventId = configurationEventbrite.GetSection(eventId).Value;
            var token = configurationEventbrite.GetSection("Token").Value;
            var eventsBasePath = configurationEventbrite.GetSection("EventsBasePath").Value;

            var attendeesUrl = eventsBasePath + eventbriteEventId + "/attendees/?token=" + token + "&page=" + page;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(attendeesUrl);
            request.Accept = "application/json";

            var rawResponse = "";
            using (WebResponse webResponse = await request.GetResponseAsync())
            using (Stream dataStream = webResponse.GetResponseStream())
            using (StreamReader reader = new StreamReader(dataStream))
            {
                rawResponse = reader.ReadToEnd();
            }

            var response = JsonConvert.DeserializeObject<LegacyEventbriteAttendeesResponse>(rawResponse);
            return response;
        }

        private bool IsValidRequest(LegacyRequestBody body)
        {
            if (body == null)
            {
                return false;
            }

            var isValidUser = body.User != null && body.User.ToLower() == this.mobileAppUser.ToLower();
            var isValidToken = body.Token != null && body.Token.ToLower() == this.mobileAppToken.ToLower();
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
        public string EventId { get; set; }
        public string Email { get; set; }
    }

    public class LegacyIsValidAttendeeResponseBody
    {
        public string Email { get; set; }
        public bool IsValid { get; set; }
    }

    public class LegacyEventbriteAttendeesResponse
    {
        [JsonProperty("pagination")]
        public Pagination Pagination { get; set; }

        [JsonProperty("attendees")]
        public IEnumerable<Attendee> attendees { get; set; }

    }
    public class Attendee
    {
        [JsonProperty("ticket_class_name")]
        public string TicketClassName { get; set; }

        [JsonProperty("profile")]
        public Profile Profile { get; set; }
    }

    public class Pagination
    {
        [JsonProperty("continuation")]
        public string Continuation { get; set; }

        [JsonProperty("has_more_items")]
        public bool HasMoreItems { get; set; }
    }

    public class Profile
    {
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
