namespace CelestialBeing.Models
{
    public class AsteroidModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double EstimatedMinimumDiameter { get; set; }
        public double EstimatedMaximumDiameter { get; set; }
        public bool PotentiallyHazardous { get; set; }
    }


}
