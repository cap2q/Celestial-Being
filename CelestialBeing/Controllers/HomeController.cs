using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CelestialBeing.Models;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Configuration;

namespace CelestialBeing.Controllers
{
    public class HomeController : Controller
    {
        // Dependency Injection to get access to BaseURL and APIKeys constructors based on definitions in appsettings.json
        IConfiguration _iconfiguration;
        public HomeController(IConfiguration iconfiguration)
        {
            _iconfiguration = iconfiguration;
        }

        public ActionResult Index()
        {
            return View();
        }
        // Concatenate the supplied date from the user via calenderpicker in the Index View to formulate our API Query to NeoWs.
        public ActionResult BuildQuery(DateModel model)
        {
            string dateSearched = $"start_date={model.DateRequested}&end_date={model.DateRequested}&{_iconfiguration.GetSection("NeoWs").GetSection("APIKey").Value}";
            return RedirectToAction("GetAsteroids", "Home", new { Query = dateSearched });
        }

        // Sends the query to the NeoWs API, waiting for a response and then returning the result to the PopulateAsteroids method.
        public async Task<ActionResult> GetAsteroids(string query)
        {
            var asteroidList = new List<AsteroidModel>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_iconfiguration.GetSection("NeoWs").GetSection("BaseURL").Value);

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage responseMessage = await client.GetAsync(_iconfiguration.GetSection("NeoWs").GetSection("BaseURL").Value + query);

                List<AsteroidModel> results = PopulateAsteroids(responseMessage);

                return View(results);
            }
        }

        // Parses the JSON received from the NeoWs API and returns a List<> with each asteroid and its relevant properties returned by the query.
        private static List<AsteroidModel> PopulateAsteroids(HttpResponseMessage queryResult)
        {
            var asteroidList = new List<AsteroidModel>();

            if (queryResult.IsSuccessStatusCode)
            {
                var responseResult = queryResult.Content.ReadAsStringAsync().Result;
                dynamic json = JValue.Parse(responseResult);

                foreach (dynamic day in json.near_earth_objects)
                {
                    foreach (dynamic occurence in day)
                    {
                        foreach (dynamic nearEarthObject in occurence)
                        {
                            var newAsteroid = new AsteroidModel();
                            newAsteroid.Id = nearEarthObject.id;
                            newAsteroid.PotentiallyHazardous = nearEarthObject.is_potentially_hazardous_asteroid;
                            newAsteroid.Name = nearEarthObject.name;
                            newAsteroid.EstimatedMinimumDiameter = nearEarthObject.estimated_diameter.miles.estimated_diameter_min;
                            newAsteroid.EstimatedMaximumDiameter = nearEarthObject.estimated_diameter.miles.estimated_diameter_max;
                            asteroidList.Add(newAsteroid);
                        }
                    }
                }
            }
            return (asteroidList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
