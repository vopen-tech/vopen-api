using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using vopen_api.Data;
using vopen_api.Models;

namespace vopen_api.Repositories
{
    public class EditionsActivitiesRepository
    {
        protected readonly VOpenDbContext dbContext;

        public EditionsActivitiesRepository(VOpenDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IReadOnlyCollection<EditionActivityDTO>> GetAllEditionActivitiesByEditionAndLanguage(string editionId, string language)
        {
            var result = await this.dbContext
                .Set<EditionActivity>()
                .Where(c => c.Edition.Id == editionId)
                .Include(c => c.Details)
                .Include(c => c.Users)
                    .ThenInclude(presenter => presenter.User)
                    .ThenInclude(presenter => presenter.Details)
                .Include(c => c.Users)
                    .ThenInclude(presenter => presenter.User)
                    .ThenInclude(user => user.SocialLinks)
                .Select(item => EditionActivityUtils.ToEditionActivityDTO(item, language))
                .ToListAsync();

            return new ReadOnlyCollection<EditionActivityDTO>(result);
        }

        public async Task<EditionActivityDTO> GetByIdAndLanguage(string id, string language)
        {
            var result = await this.dbContext
                .Set<EditionActivity>()
                .Where(c => c.Id == id)
                .Include(c => c.Details)
                .Include(c => c.Users)
                    .ThenInclude(presenter => presenter.User)
                    .ThenInclude(presenter => presenter.Details)
                .Include(c => c.Users)
                    .ThenInclude(presenter => presenter.User)
                    .ThenInclude(user => user.SocialLinks)
                .Select(item => EditionActivityUtils.ToEditionActivityDTO(item, language))
                .FirstOrDefaultAsync();

            return result;
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
