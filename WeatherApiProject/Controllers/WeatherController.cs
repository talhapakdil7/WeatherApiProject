using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherApiProject.Context;
using WeatherApiProject.Entities;

namespace WeatherApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        WeatherContext context = new WeatherContext();

        [HttpGet]

        public IActionResult GetCities()
        {
            var cities = context.Cities.ToList();
            if (cities == null || !cities.Any())
            {
                return NotFound("No cities found.");
            }
            return Ok(cities);


        }

        [HttpPost]

        public IActionResult AddCity(City city)
        {

            context.Cities.Add(city);
            context.SaveChanges();
            return Ok("City added successfully.");
        }


        [HttpDelete]

        public IActionResult DeleteCity(int id)
        {

            var values = context.Cities.Find(id);

            context.Cities.Remove(values);
            context.SaveChanges();

            return Ok("City deleted successfully.");




        }


        [HttpPut]

        public IActionResult PutCity(City city)
        {

            {

                var values = context.Cities.Find(city.CityId);

                values.CityName = city.CityName;
                values.Country = city.Country;
                values.Detail = city.Detail;
                values.Temp = city.Temp;

                context.SaveChanges();



                return Ok("City updated successfully.");

            }

        }



        [HttpGet("GetByCity")]

        public IActionResult GetByCity(int id)
        {
            var values = context.Cities.Find(id);

            return Ok(values);



        }

        [HttpGet("TotalCityCount")]


        public IActionResult TotalCityCount()
        {
            var values = context.Cities.Count();
            return Ok("Total city count: " + values);

        }


        [HttpGet("GetRainyWeather")]

        public IActionResult GetRainyWeather(string detail)
        {
            

        var values= context.Cities.Where(i=>i.Detail==detail).ToList();

            //where bıze satır dondurur

            return Ok(values);


        }

        [HttpGet("MaxTempCity")]

        public IActionResult MaxTemCity()
        {
           

           var values=context.Cities.OrderByDescending(i => i.Temp).FirstOrDefault();
            if (values == null)
            {
                return NotFound("No cities found.");
            }
            return Ok(values);

        


        }

        [HttpGet("MinTempCity")]


        public IActionResult MinTempCity()
        {

            var values = context.Cities.OrderBy(i=>i.Temp).FirstOrDefault();

            return Ok(values);





        }


        //ulkesı turkıye ve yagmurlu olan


        [HttpGet("GetTurkeyRainyCities")]


        public IActionResult GetTurkeyRainyCities(string country,string detail)
        {

        var values=    context.Cities.Where(i => i.Country == country && i.Detail == detail);

            return Ok(values.ToList());


        }


    }

}
