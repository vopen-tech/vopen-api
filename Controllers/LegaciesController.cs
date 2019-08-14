﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using vopen_api.Models;
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
        private IMemoryCache _cache;
        private readonly string country;
        private readonly string edition;

        public LegaciesController(EditionsRepository editionsRepository, IConfiguration configuration, IMemoryCache memoryCache)
        {
            this.editionsRepository = editionsRepository;
            this.configuration = configuration;
            this._cache = memoryCache;
            this.country = configuration.GetSection("Country").Value;
            this.edition = configuration.GetSection("Edition").Value;
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

            LegacySponsorsDTO result;
            var _cacheName = this.edition + "-sponsors";

            if (!_cache.TryGetValue(_cacheName, out result)){

                var edition = await editionsRepository.GetByLanguageAndId("es", this.edition);
                result = new LegacySponsorsDTO();
                result.imageBaseURL = configuration.GetSection("SiteUrl").Value
                                                + "Content/images/demo/sponsor-logos/";
                result.info = "All images are .png";

                result.sponsors = (from r in edition.Sponsors
                                   select
                    (new LegacySponsor()
                    {
                        Name = r.Name,
                        GlobalRanking = 1,
                        LogoFileName = "",
                        SponsorId = 0,
                        WebSite = r.Url
                    })).ToList();

                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(300));
                _cache.Set(_cacheName, result, cacheEntryOptions);
            }
            
            return Ok(result);
        }

        //devuelve modelo ConfSponsors
        [HttpPost("ConfSponsors")]
        public async Task<IActionResult> ConfSponsors(LegacyApiCredentialsDTO dto)
        {
            this.ValidateRequest(dto);

            LegacyConfSponsorsDTO result;
            var _cacheName = this.edition + "-confsponsors";

            if (!_cache.TryGetValue(_cacheName, out result))
            {

                var edition = await editionsRepository.GetByLanguageAndId("es", this.edition);
                result = new LegacyConfSponsorsDTO();
                result.imageBaseURL = configuration.GetSection("SiteUrl").Value;
                
                //rebuild
                result.confSponsors = (from r in edition.Sponsors
                                   select
                    (new ConfSponsors()
                    {
                      SponsorId = 0,
                      Sponsor = new LegacySponsor() {
                           Name = r.Name,
                           GlobalRanking = 1,
                           LogoFileName = "",
                           SponsorId = 0,
                           WebSite = r.Url
                       },
                      SponsorCategoryId = 0,
                      SponsorCategory = new List<SponsorCategory>(),
                      HasBooth = false

                    })).ToList();

                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(300));
                _cache.Set(_cacheName, result, cacheEntryOptions);
            }

            return Ok(result);
        }

        //devuelte integer
        [HttpPost("Editions")]
        public async Task<IActionResult> Editions(LegacyApiCredentialsDTO dto)
        {
            this.ValidateRequest(dto);
            IList<string> result;
            var _cacheName = this.edition + "-editions";

            if (!_cache.TryGetValue(_cacheName, out result))
            {

                var edition = await editionsRepository.GetAllByLanguage("es");
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(300));

                result = (from r in edition select r.Name).ToList();

                _cache.Set(_cacheName, result, cacheEntryOptions);
            }

            return Ok(result);
        }

        [HttpPost("AppConfig")]
        public async Task<IActionResult> AppConfig(LegacyApiCredentialsDTO dto)
        {
            this.ValidateRequest(dto);

            var _cacheName = this.edition + "-appconfig";

            LegacyAppConfigDTO appConfig;

            if (!_cache.TryGetValue(_cacheName, out appConfig))
            {

                var edition = await editionsRepository.GetByLanguageAndId("es", this.edition);
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(300));

                appConfig.HighlightedSponsors = (from r in edition.Sponsors
                                   select
                                        (new LegacySponsor()
                                        {
                                            Name = r.Name,
                                            GlobalRanking = 1,
                                            LogoFileName = "",
                                            SponsorId = 0,
                                            WebSite = r.Url
                                        })).ToList();

                //falta HighlightedSponsorsIds
                //fatla Texts

                _cache.Set(_cacheName, appConfig, cacheEntryOptions);
            }

            return Ok(appConfig);
        }

        //eventbrite
        [HttpPost("IsValidAttendee")]
        public async Task<IActionResult> IsValidAttendee(LegacyIsValidAttendeeDTO dto)
        {
            this.ValidateRequest(dto);
            var _cacheName = this.edition + "-" + dto.Email;
            LegacyEventbriteAttendeesResponse.Attendee result;

            if (!_cache.TryGetValue(_cacheName, out result))
            {

                var configurationEventBrite = configuration.GetSection("EventBrite");
                var eventBriteId = configurationEventBrite.GetSection("EventbriteEventId").Value;
                var eventBriteUSer = configurationEventBrite.GetSection("User").Value;
                var eventBriteKey = configurationEventBrite.GetSection("Key").Value;
                var eventBriteClientSecret = configurationEventBrite.GetSection("ClientSecret").Value;
                var eventBriteOAuthTokenPersonal = configurationEventBrite.GetSection("OAuthTokenPersonal").Value;
                var eventBriteOAuthTokenAnonymous = configurationEventBrite.GetSection("OAuthTokenAnonymous").Value;
                var eventBriteAttendeesAddress = configurationEventBrite.GetSection("AttendeesAddress").Value +
                                                    configurationEventBrite + "/attendees/?token=" + eventBriteOAuthTokenPersonal;
                var eventbriteTicketNamesAllowedInRaffle = configuration.GetSection("EventbriteTicketNamesAllowedInRaffle").Value;


                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;


                /// Esto no se usa siempre llega null
                //if (pageContinuation != null)
                //{
                //    attendeesAddress += "&continuation=" + pageContinuation;
                //}


                string attendeesRawResponse;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(eventBriteAttendeesAddress);
                request.Accept = "application/json";
                using (WebResponse response = await request.GetResponseAsync())
                {
                    using (Stream dataStream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(dataStream))
                        {
                            attendeesRawResponse = reader.ReadToEnd();
                        }
                    }
                }

                var attendeesResponse = Newtonsoft.Json.JsonConvert
                  .DeserializeObject<LegacyEventbriteAttendeesResponse>(attendeesRawResponse);

                result = attendeesResponse.attendees
                    .FirstOrDefault(a => a.profile.email.ToLowerInvariant() == dto.Email.ToLowerInvariant());

                //NO se usa paginación
                //if (attendee == null && attendeesResponse.pagination.has_more_items)
                //{
                //    attendee = await AttendeeFacade.GetEventbriteAttendee(eventbriteEventId, email,
                //        attendeesResponse.pagination.continuation);
                //}

                if (attendeesResponse != null)
                {
                    if (eventbriteTicketNamesAllowedInRaffle.ToLower().Contains(
                        result.ticket_class_name.ToLower()) == false)
                    {
                        result = null; // Found but ticket not allowed.
                    }
                }

                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(300));
                _cache.Set(_cacheName, result, cacheEntryOptions);
            }

            return Ok(result);
        }

    }
}