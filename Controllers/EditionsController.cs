using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using vopen_api.Models;
using vopen_api.Repositories;

namespace vopen_api.Controllers
{
    [Route("api/v1/editions")]
    [ApiController]
    public class EditionsController : ControllerBase
    {
        private readonly EditionsRepository editionsRepository;
        private readonly LegacyGlobalRepository legacyGlobalRepository;

        private readonly ILogger logger;
        private readonly CacheService cacheService;

        public EditionsController(EditionsRepository editionsRepository, LegacyGlobalRepository legacyGlobalRepository, ILogger<LegaciesController> logger, IMemoryCache memoryCache)
        {
            this.editionsRepository = editionsRepository;
            this.legacyGlobalRepository = legacyGlobalRepository;

            this.logger = logger;
            this.cacheService = new CacheService(memoryCache);
        }

        // GET api/v1/editions
        [HttpGet]
        public async Task<IEnumerable<EditionDTO>> GetAllAsync()
        {
            var language = this.GetLanguage();
            return await this.editionsRepository.GetAllByLanguage(language);
        }

        // GET api/v1/editions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {

            if (id == "vopen-global-legacy")
            {
                return Ok(GetEditionFromLegacy(id));
            }

            var language = this.GetLanguage();            
            string cacheKey = $"Editions-GetByIdAsync-{id}-{language}";
            var cacheResult = this.cacheService.GetValue<EditionDTO>(cacheKey);

            if (cacheResult != null) {
                this.logger.LogInformation($"Retrieving data with key '{cacheKey}' from cache");
                return Ok(cacheResult);
            }
            
            var result = await this.editionsRepository.GetByLanguageAndId(language, id);

            if (result == null)
            {
                return NotFound();
            }

            this.cacheService.SetValue(cacheKey, cacheResult);
            return Ok(result);
        }

        private EditionDTO  GetEditionFromLegacy(string id) {

            string cacheKey = $"Editions-GetByIdAsync-legacy-{id}";
            var cacheResult = this.cacheService.GetValue<EditionDTO>(cacheKey);

            if (cacheResult != null)
            {
                this.logger.LogInformation($"Retrieving data with key '{cacheKey}' from cache");
            }
            else
            {
                cacheResult = this.legacyGlobalRepository.GetEdition(id);
                this.cacheService.SetValue(cacheKey, cacheResult);
            }

            return cacheResult;
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
}
