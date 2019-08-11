using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using vopen_api.Data;
using vopen_api.Models;

namespace vopen_api.Repositories
{
    public class EditionsRepository : IMultiLanguageRepository<EditionDTO>
    {
        protected readonly VOpenDbContext dbContext;

        public EditionsRepository(VOpenDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<IReadOnlyCollection<EditionDTO>> GetAllByLanguage(string language)
        {
            throw new System.NotImplementedException();
        }

        public async Task<EditionDTO> GetByLanguageAndId(string language, string id)
        {
            var result = await this.dbContext
                .Set<Edition>()
                .Include(item => item.Details)
                .Include(item => item.Event)
                .Include(item => item.TicketInfo)
                .Include(item => item.Location)
                .Include(item => item.Organizers)
                .Include(item => item.Sponsors)
                .Include(item => item.Activities)
                .FirstOrDefaultAsync(item => item.Id == id);

            if (result == null)
            {
                return null;
            }

            return EditionUtils.ToEditionDTO(result, language);
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
