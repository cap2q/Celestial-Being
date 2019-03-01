using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CelestialBeing.Models
{
    public class Asteroid
    {
        public Links Links { get; set; }
        [JsonProperty("element_count")]
        public int ElementCount { get; set; }
        [JsonProperty("near_earth_object")]
        public NearEarthObjects NearEarthObjects { get; set; }

    }

    public class Links
    {
        public string Next { get; set; }
        public string Prev { get; set; }
        public string Self { get; set; }
    }

    public class EstimatedDiameter
    {
        public float Miles { get; set; }
    }

    public class Miles
    {
        [JsonProperty("estimated_diameter_min")]
        public float MinEstimatedDiameter { get; set; }
        [JsonProperty("estimated_diameter_max")]
        public float MaxEstimatedDiameter { get; set; }
    }

    public class NearEarthObjects
    {
        public string Occurences { get; set; }
    }
}
