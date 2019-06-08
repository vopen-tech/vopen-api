using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using vopen_api.Models;
using vopen_api.Repositories;

namespace vopen_api.Controllers
{
    [Route("api/v1/conferences")]
    [ApiController]
    public class ConferencesController : ControllerBase
    {
        private ConferencesRepository conferencesRepository;

        public ConferencesController(IHostingEnvironment env)
        {
            this.conferencesRepository = new ConferencesRepository(env);
        }

        // GET api/v1/conferences
        [HttpGet]
        public IEnumerable<Conference> Get()
        {
            return this.conferencesRepository.GetAll();
        }

        // GET api/v1/conferences/5
        [HttpGet("{id}")]
        public Conference Get(string id)
        {
            return this.conferencesRepository.GetById(id);
        }

        // POST api/v1/conferences
        [HttpPost]
        public void Post([FromBody] Conference value)
        {

        }

        // PUT api/v1/conferences/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Conference value)
        {
        }

        // DELETE api/v1/conferences/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
        }
    }
}
