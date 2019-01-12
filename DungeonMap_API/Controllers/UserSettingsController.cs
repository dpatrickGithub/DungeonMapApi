using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DungeonMap_API.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DungeonMap_API.Controllers
{
    [Route("api/[controller]")]
    public class UserSettingsController : Controller
    {
        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            //get from db
            return Ok(new SettingsModel());
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
    }
}
