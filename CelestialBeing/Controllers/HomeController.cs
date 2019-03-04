using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CelestialBeing.Models;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace CelestialBeing.Controllers
{
    public class HomeController : Controller
    {
        const string baseURL = "https://api.nasa.gov/neo/rest/v1/feed?";
        const string apiKey = "api_key=ltq5tyqWqJ2SppBtiQWJXAwdl45mtydCpr4NJU5h";

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BuildQuery(DateModel model)
        {
            string dateSearched = "start_date=" + model.DateRequested + "&" + "end_date=" + model.DateRequested + "&" + apiKey;
            return RedirectToAction("CompileResults", "Home", new { Query = dateSearched });
        }

        public async Task<ActionResult> CompileResults(string query)
        {
            var asteroidList = new List<AsteroidModel>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage responseMessage = await client.GetAsync(baseURL + query);

                List<AsteroidModel> results = PopulateAsteroids(responseMessage);

                return View(results);
            }
        }


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
