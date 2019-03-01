using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CelestialBeing.Models;
using Newtonsoft.Json;
using System.Net.Http;

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

        [HttpPost]
        public ActionResult Date(DateModel model)
        {
            string dateSearched = "start_date=" + model.Year + "-" + model.Month + "-" + model.Day + "&";
            return RedirectToAction("Results", "Home", new { Date = dateSearched } );
        }
        public async Task<ActionResult> Results(string date)
        {

            var data = new AsteroidModel();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);

                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage responseMessage = await client.GetAsync(baseURL + date + apiKey);
                
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseResult = responseMessage.Content.ReadAsStringAsync().Result;
                    data = JsonConvert.DeserializeObject<AsteroidModel>(responseResult);
                }
                return View(data);
            }
        }
        
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}
