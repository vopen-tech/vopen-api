using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
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
        private readonly string mobileAppUser;
        private readonly string mobileAppToken;

        private readonly ILogger logger;
        private readonly CacheService cacheService;

        public LegaciesController(EditionsRepository editionsRepository, IConfiguration configuration, ILogger<LegaciesController> logger, IMemoryCache memoryCache)
        {
            this.editionsRepository = editionsRepository;
            this.configuration = configuration;
            this.logger = logger;
            this.cacheService = new CacheService(memoryCache);

            var configurationMobileApp = configuration.GetSection("MobileApp");
            this.mobileAppUser = configurationMobileApp.GetSection("User").Value;
            this.mobileAppToken = configurationMobileApp.GetSection("Token").Value;
        }

        [HttpPost("{editionId}/confSponsors")]
        public async Task<IActionResult> ConfSponsors(string editionId, LegacyRequestBody body)
        {
            if (!this.IsValidRequest(body))
            {
                return Unauthorized("Invalid client");
            }

            var language = this.GetLanguage();
            string cacheKey = $"ConfSponsors-{editionId}-{language}";
            this.logger.LogInformation($"Retrieving data with key '{cacheKey}' from cache");
            var cacheResult = this.cacheService.GetValue<LegacyConfSponsorsDTO>(cacheKey);

            if (cacheResult != null)
            {
                this.logger.LogInformation($"Retrieved from cache");
                return Ok(cacheResult);
            }

            this.logger.LogInformation($"Not found in cache");
            
            var edition = await this.editionsRepository.GetByLanguageAndId(language, editionId);
            var legacyConfSponsors = LegacyConfSponsorsUtils.ToLegacyConfSponsorsDTO(edition.Sponsors);
            this.cacheService.SetValue(cacheKey, legacyConfSponsors);

            return Ok(legacyConfSponsors);
        }

        [HttpPost("{editionId}/IsValidAttendee")]
        public async Task<IActionResult> IsValidAttendee(string editionId, LegacyIsValidAttendeeRequestBody attendeeBody)
        {
            if (!this.IsValidRequest(attendeeBody))
            {
                return Unauthorized("Invalid client");
            }

            string cacheKey = $"IsValidAttendee-{editionId}-{attendeeBody.Email}";
            this.logger.LogInformation($"Retrieving data with key '{cacheKey}' from cache");
            var cacheResult = this.cacheService.GetValue<LegacyIsValidAttendeeResponseBody>(cacheKey);

            if (cacheResult != null)
            {
                this.logger.LogInformation($"Retrieved from cache");
                return Ok(cacheResult);
            }

            this.logger.LogInformation($"Not found in cache");

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
                    var response = await this.GetAttendeesInEdition(editionId, page);
                    var attendee = response.attendees
                        .FirstOrDefault(item =>
                          item.Profile.Email != null && item.Profile.Email.ToLowerInvariant() == attendeeBody.Email.ToLowerInvariant()
                          && ticketNamesAllowedInRaffle.ToLower().Contains(item.TicketClassName.ToLowerInvariant())
                        );

                    attendeeFound = attendee != null;
                    hasMorePages = response.Pagination.HasMoreItems;
                    page += 1;
                }
               
                result.IsValid = attendeeFound;

                if (result.IsValid)
                {
                    this.cacheService.SetValue(cacheKey, result);
                }

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        private async Task<LegacyEventbriteAttendeesResponse> GetAttendeesInEdition(string eventId, int page = 1)
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
