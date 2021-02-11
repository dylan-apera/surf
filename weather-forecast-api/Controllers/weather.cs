using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace weather_forecast_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class Weather : ControllerBase
    {

        private static ConcurrentDictionary<string, Surf> _data = new ConcurrentDictionary<string, Surf>();

        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(_data.Select(d => d.Value)); //lambda
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            if (_data.TryGetValue(id, out Surf surf))
                return new JsonResult(surf);            
            else
                return NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Surf surf)
        {
            if (_data.TryAdd(surf.Id, surf))
                return new JsonResult(surf);
            else
                return Conflict();

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if (_data.TryRemove(id, out _))//example of a discard "_" 
                return Ok();
            else 
                return NotFound();

        }
        /*
        [HttpPut]
        public IActionResult Put(string id, [FromBody] Surf surf)
        {
            _data.TryUpdate( TryAdd(surf.Id, surf);
            return Ok();
        }*/

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Surf surf)
        {
            _data.TryUpdate(id, TryAdd(Surf.id, Surf surf));
         
            return Ok();
        }
        public class Surf
        {
            public string Id { get; set; } 
            public string surfSpot { get; set; }
            public string weather { get; set; }
        }
    }
    
}