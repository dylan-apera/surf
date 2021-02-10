using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
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
            return new JsonResult(_data);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Surf surf)
        {
            _data.TryAdd(surf.Id, surf);
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