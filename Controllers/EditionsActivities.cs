using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using vopen_api.Data;
using vopen_api.Models;

namespace vopen_api.Controllers
{
    [Route("api/v1/editions/{id}/activities")]
    [ApiController]
    public class EditionsActivities
    {
       
        // GET api/v1/editions/5/activities
        [HttpGet]
        public async Task<IEnumerable<EditionActivityDTO>> GetAllAsync()
        {
            return await Task.FromResult(new List<EditionActivityDTO>());
        }

        // GET api/v1/editions/5/activities/6
        [HttpGet("{activityId}")]
        public async Task<EditionActivityDTO> GetById(string activityId)
        {
            return await Task.FromResult(new EditionActivityDTO() { Id = activityId });
        }

        // POST api/v1/editions/5/activities/6/vote
        [HttpPost("{activityId}/vote")]
        public async Task<EditionActivityScore> VoteActivity(string activityId, [FromBody]Vote vote)
        {
            var score = new EditionActivityScore
            {
                UserEmail = vote.Email,
                Score = vote.Score,
                Comments = vote.Comments,
            };

            return await Task.FromResult(score);
        }

        public class Vote
        {
            public string Email { get; set; }
            public int Score { get; set; }
            public string Comments { get; set; }
        }
    }
}
