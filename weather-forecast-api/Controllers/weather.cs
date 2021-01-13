using Microsoft.AspNetCore.Mvc;
using System;
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
        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult Get()
        {
            var weatherForecast = new[]
            {
                new { breakName = "Muriawai", highTide = "12:30AM & 11:00 AM", lowTide = "6:30AM & 5:PM", wind = "North North East Winds @ 3 knots", swell = "1.2M from the West"},
                new { breakName = "Hamilton", highTide = "12:30AM & 11:00 AM", lowTide = "6:30AM & 5:PM", wind = "North North East Winds @ 3 knots", swell = "1.2M from the West"},
                new { breakName = "Social Center", highTide = "12:30AM & 11:00 AM", lowTide = "6:30AM & 5:PM", wind = "East Winds @ 10 knots", swell = "1.2M from the West"}
            };
            return new JsonResult(weatherForecast);
        }            
    }
}
//Adding comment to test authorisation issues
/*

    [Route("[controller]")]
    [ApiController]
    public class Reviews : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult Get()
        {
            var surfReviews = new[]
            {
                new { surfer= "Dan Larsen", comment = "This spot is sick! "}
            };

            return new JsonResult(surfReviews);
        }


    public class person
    {
        public string name { get; set; }
        public string surname { get; set; }
    }
    [HttpPost]
    public void Post([FromBody] person p)
    {
        return new JsonResult(person.p);
    }

}*/


