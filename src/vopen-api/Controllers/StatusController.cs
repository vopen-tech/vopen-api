using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using vopen_api.Models;
using vopen_api.Repositories;

namespace vopen_api.Controllers
{
    [Route("api/v1/status")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        public IConfiguration Configuration { get; }

        public StatusController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // GET api/v1/status/ping
        [HttpGet("ping")]
        public ActionResult Ping()
        {
            var connString = this.Configuration.GetConnectionString("DefaultConnection");
            return Ok(connString.Length > 0 ? connString : "empty");
        }
    }
}
