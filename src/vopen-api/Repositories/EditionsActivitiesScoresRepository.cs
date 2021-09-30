using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using vopen_api.Data;
using vopen_api.Models;

namespace vopen_api.Repositories
{
    public class EditionsActivitiesScoresRepository
    {
        protected readonly VOpenDbContext dbContext;
        

        public EditionsActivitiesScoresRepository(VOpenDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<EditionActivityScore> Vote(string editionActivityId, string userEmail, double score, string comments)
        {
            var editionActivity = await this.dbContext.Set<EditionActivity>().Where(c => c.Id == editionActivityId).FirstOrDefaultAsync();

            if (editionActivity == null)
            {
                throw new InvalidOperationException($"The activity with ID {editionActivityId} was not found");
            }

            var editionActivityScore = new EditionActivityScore
            {
                EditionActivity = editionActivity,
                UserEmail = userEmail,
                Score = score,
                Comments = comments
            };

            this.dbContext.EditionsActivitiesScores.Add(editionActivityScore);
            await this.dbContext.SaveChangesAsync();

            return editionActivityScore;
        }

        public Task<EditionDTO> Create(EditionDTO entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<EditionDTO> Update(EditionDTO entity)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}
