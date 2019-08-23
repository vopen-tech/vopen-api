using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using vopen_api.Models.legacy;
using vopen_api.Repositories;
using static vopen_api.Models.legacy.LegacyEventbriteAttendeesResponse;

namespace vopen_api.Controllers
{
    [Route("legacy/api/v1/{edition}")]
    [ApiController]
    public class LegaciesController : ControllerBase
    {
        private readonly EditionsRepository editionsRepository;
        private readonly IConfiguration configuration;
        private readonly string eventbriteEdition;
        private readonly string MOBILE_APP_USER;
        private readonly string MOBILE_APP_TOKEN;

        private readonly string country;
        private readonly string edition;

        public LegaciesController(EditionsRepository editionsRepository, IConfiguration configuration)
        {
            this.editionsRepository = editionsRepository;
            this.configuration = configuration;
            this.eventbriteEdition = configuration.GetSection("Edition").Value; // e.g vopen-ar-2019

            this.country = configuration.GetSection("Country").Value;
            this.edition = configuration.GetSection("Edition").Value;

            this.MOBILE_APP_USER = configuration.GetSection("MOBILE_APP_USER").Value;
            this.MOBILE_APP_TOKEN = configuration.GetSection("MOBILE_APP_TOKEN").Value; ;
        }

        //devuelve modelo LegacySpronsor
        [HttpPost("Sponsors")]
        public async Task<IActionResult> Sponsors(LegacyApiCredentialsDTO dto)
        {
            this.IsValidRequest(dto);

            var edition = await editionsRepository.GetByLanguageAndId("es", this.edition);
            var result = new LegacySponsorsDTO();
            result.imageBaseURL = configuration.GetSection("SiteUrl").Value
                                            + "Content/images/demo/sponsor-logos/";
            result.info = "All images are .png";

            result.sponsors = (from r in edition.Sponsors
                               select (new LegacySponsor()
                               {
                                   Name = r.Name,
                                   GlobalRanking = 0,
                                   LogoFileName = r.ImageUrl,
                                   SponsorId = r.Id,
                                   WebSite = r.Url
                               })).ToList();

            return Ok(result);
        }

        //devuelve modelo ConfSponsors
        [HttpPost("ConfSponsors")]
        public async Task<IActionResult> ConfSponsors(LegacyApiCredentialsDTO dto)
        {
            this.IsValidRequest(dto);

            LegacyConfSponsorsDTO result;

            var edition = await editionsRepository.GetByLanguageAndId("es", this.edition);
            result = new LegacyConfSponsorsDTO();
            result.imageBaseURL = configuration.GetSection("SiteUrl").Value;

            //rebuild
            result.confSponsors = (from r in edition.Sponsors
                                   select
                   (new ConfSponsors()
                   {
                       SponsorId = 0,
                       Sponsor = new LegacySponsor()
                       {
                           Name = r.Name,
                           GlobalRanking = 0, //no se utiliza en la app
                            LogoFileName = r.ImageUrl,
                           SponsorId = r.Id,
                           WebSite = r.Url
                       },
                       SponsorCategoryId = GetSponsorCategoryId(r.Type),
                       SponsorCategory = GetSponsorCategory(r.Type),
                       HasBooth = GetSponsorCategoryId(r.Type) == 1 ? false : true
                   })).ToList();

            return Ok(result);
        }

        // Eventbrite endpoint 
        [HttpPost("IsValidAttendee")]
        public async Task<IActionResult> IsValidAttendee(LegacyIsValidAttendeeDTO attendeeInfo)
        {
            if (!this.IsValidRequest(attendeeInfo))
            {
                return Unauthorized();
            }

            Attendee result = null;

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
                    result = attendeesResponse.attendees.FirstOrDefault(a => a.profile.email.ToLowerInvariant() == attendeeInfo.Email.ToLowerInvariant());
                }

                return Ok(result);
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }

        private bool IsValidRequest(LegacyApiCredentialsDTO attendeeInfo)
        {
            if (attendeeInfo == null)
            {
                return false;
            }

            var isValidUser = attendeeInfo.User != null && attendeeInfo.User.ToLower() == this.MOBILE_APP_USER;
            var isValidToken = attendeeInfo.Token != null && attendeeInfo.Token.ToUpper() == this.MOBILE_APP_TOKEN;
            return isValidUser && isValidToken;
        }

        private IList<SponsorCategory> GetSponsorCategory(string sponsorshipType)
        {

            IList<SponsorCategory> listSponsorCategory = new List<SponsorCategory>();

            listSponsorCategory.Add(GetSponsorCategories()
                                    .Where(p => p.Name == sponsorshipType.ToUpper())
                                        .SingleOrDefault());
            return listSponsorCategory;
        }

        private int GetSponsorCategoryId(string sponsorshipType)
        {

            return GetSponsorCategories()
                        .Where(p => p.Name == sponsorshipType.ToUpper())
                            .SingleOrDefault().SponsorCategoryId;
        }

        public IList<SponsorCategory> GetSponsorCategories()
        {
            IList<SponsorCategory> listSponsorCategory = new List<SponsorCategory>();
            listSponsorCategory.Add(new SponsorCategory()
            {
                SponsorCategoryId = 6,
                Name = "DIAMOND"
            });

            listSponsorCategory.Add(new SponsorCategory()
            {
                SponsorCategoryId = 4,
                Name = "GOLD"
            });

            listSponsorCategory.Add(new SponsorCategory()
            {
                SponsorCategoryId = 2,
                Name = "SILVER"
            });

            listSponsorCategory.Add(new SponsorCategory()
            {
                SponsorCategoryId = 1,
                Name = "DIGITAL"
            });

            return listSponsorCategory;
        }
    }
}