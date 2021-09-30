using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using vopen_api.Data;
using vopen_api.Models;
using vopen_api.Repositories;

namespace vopen_api.Controllers
{
    [Route("api/v1/editions/{editionId}/activities")]
    [ApiController]
    public class EditionsActivitiesController : ControllerBase
    {
        protected readonly EditionsActivitiesRepository editionsActivitiesRepository;
        private readonly EditionsActivitiesScoresRepository editionsActivitiesScoresRepository;

        public EditionsActivitiesController(EditionsActivitiesRepository editionsActivitiesRepository, EditionsActivitiesScoresRepository editionsActivitiesScoresRepository)
        {
            this.editionsActivitiesRepository = editionsActivitiesRepository;
            this.editionsActivitiesScoresRepository = editionsActivitiesScoresRepository;
        }

        // GET api/v1/editions/5/activities
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(string editionId)
        {
            var language = this.GetLanguage();
            var result = await this.editionsActivitiesRepository.GetAllEditionActivitiesByEditionAndLanguage(editionId, language);
            return Ok(result);
        }

        // GET api/v1/editions/5/activities/6
        [HttpGet("{activityId}")]
        public async Task<IActionResult> GetByIdAndLanguage(string activityId)
        {
            var language = this.GetLanguage();
            var editionActivity = await this.editionsActivitiesRepository.GetByIdAndLanguage(activityId, language);
            return Ok(editionActivity);
        }

        // POST api/v1/editions/5/activities/6/vote
        [HttpPost("{activityId}/vote")]
        public async Task<IActionResult> VoteActivity(string activityId, [FromBody]Vote vote)
        {
            var language = this.GetLanguage();
            var editionActivity = await this.editionsActivitiesRepository.GetByIdAndLanguage(activityId, language);

            if (editionActivity == null)
            {
                return NotFound($"The activity with ID {activityId} was not found");
            }

            var newScore = await this.editionsActivitiesScoresRepository.Vote(activityId, vote.Email, vote.Score, vote.Comments);
            vote.EditionActivityId = newScore.EditionActivity.Id;

            return CreatedAtAction(nameof(VoteActivity), new { id = newScore.Id }, vote);
        }

        public class Vote
        {
            public string EditionActivityId { get; set; }
            public string Email { get; set; }
            public double Score { get; set; }
            public string Comments { get; set; }
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
