﻿using System.Collections.Generic;
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

        public async Task<IReadOnlyCollection<EditionDTO>> GetAllByLanguage(string language)
        {
            var result = await this.dbContext
                .Set<Edition>()
                .Include(item => item.Details)
                .Include(item => item.Event)
                .Select(item => EditionUtils.ToEditionDTO(item, language))
                .ToListAsync();

            return new ReadOnlyCollection<EditionDTO>(result);
        }

        public async Task<EditionDTO> GetByLanguageAndId(string language, string id)
        {
            var result = await this.dbContext
                .Set<Edition>()
                .Include(item => item.Details)
                .Include(item => item.Event)
                .Include(item => item.Organizers)
                    .ThenInclude(organizer => organizer.User)
                    .ThenInclude(user => user.Details)
                .Include(item => item.Organizers)
                    .ThenInclude(organizer => organizer.User)
                    .ThenInclude(user => user.SocialLinks)
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
