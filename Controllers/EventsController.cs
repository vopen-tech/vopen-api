using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using vopen_api.Models;
using vopen_api.Repositories;

namespace vopen_api.Controllers
{
    [Route("api/v1/events")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly EventsRepository eventsRepository;

        public EventsController(EventsRepository eventsRepository)
        {
            this.eventsRepository = eventsRepository;
        }

        // GET api/v1/conferences
        [HttpGet]
        public async Task<IEnumerable<EventDTO>> GetAllAsync()
        {
            var language = (string)Request.Headers["Accept-Language"] ?? "es-AR";
            return await this.eventsRepository.GetAllByLanguage(language);
        }

        // GET api/v1/event/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            var language = (string)Request.Headers["Accept-Language"] ?? "es-AR";
            var result = await this.eventsRepository.GetByLanguageAndId(language, id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // POST api/v1/event
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EventDTO newEvent)
        {
            var result = await this.eventsRepository.Create(newEvent);

            if (result == null)
            {
                return null;
            }

            return CreatedAtAction(nameof(GetByIdAsync), new { id = newEvent.Id }, newEvent);
        }

        // PUT api/v1/event/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(String id, [FromBody] EventDTO updatedEvent)
        {
            if (id != updatedEvent.Id)
            {
                return BadRequest();
            }

            var result = await this.eventsRepository.Update(updatedEvent);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // DELETE api/v1/event/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await this.eventsRepository.Delete(id);
            return NoContent();
        }
    }
}
