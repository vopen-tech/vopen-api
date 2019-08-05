using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using vopen_api.Data;
using vopen_api.Models;

namespace vopen_api.Repositories
{
    public class EventsRepository : IMultiLanguageRepository<EventDTO>
    {
        protected readonly VOpenDbContext dbContext;

        public EventsRepository(VOpenDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IReadOnlyCollection<EventDTO>> GetAllByLanguage(string language)
        {
            var result = await this.dbContext
                .Set<Event>()
                .Include(item => item.Details)
                .Select(item => EventUtils.ToEventDTO(item, language))
                .ToListAsync();

            return new ReadOnlyCollection<EventDTO>(result);
        }

        public async Task<EventDTO> GetByLanguageAndId(string language, string id)
        {
            var result = await this.dbContext
                .Set<Event>()
                .Include(item => item.Details)
                .FirstOrDefaultAsync(item => item.Id == id);

            if (result == null)
            {
                return null;
            }

            return EventUtils.ToEventDTO(result, language);
        }

        public async Task<EventDTO> Create(EventDTO entity)
        {
            var newEvent = new Event() { Id = entity.Id };
            var newEventDetail = EventUtils.FromEventDTO(entity);
            this.dbContext.Set<Event>().Add(newEvent);
            await this.dbContext.SaveChangesAsync();

            return EventUtils.ToEventDTO(newEvent, entity.Language);
        }

        public async Task<EventDTO> Update(EventDTO entity)
        {
            var eventToUpdate = await this.dbContext
                .Set<Event>()
                .Include(item => item.Details)
                .FirstOrDefaultAsync(item => item.Id == entity.Id);

            if (eventToUpdate == null)
            {
                return null;
            }

            var eventDetailsToUpdate = eventToUpdate.Details.FirstOrDefault(itemDetail => itemDetail.Language == entity.Language);
            if (eventDetailsToUpdate == null)
            {
                // Add a new detail (of a new language)
                eventToUpdate.Details.Add(new EventDetail
                {
                    Language = entity.Language,
                    Name = entity.Name,
                    Description = entity.Description
                });
            }
            else
            {
                // Update existing detail
                eventDetailsToUpdate.Name = entity.Name;
                eventDetailsToUpdate.Description = entity.Description;
            }

            this.dbContext.Set<Event>().Update(eventToUpdate);
            await this.dbContext.SaveChangesAsync();

            return EventUtils.ToEventDTO(eventToUpdate, entity.Language);
        }

        public async Task Delete(string id)
        {
            var result = await this.dbContext
                .Set<Event>()
                .Include(item => item.Details)
                .FirstOrDefaultAsync(item => item.Id == id);

            if (result == null)
            {
                return;
            }

            this.dbContext.RemoveRange(result);
            this.dbContext.Remove(result);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
