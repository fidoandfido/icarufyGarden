using System;

namespace IcarufyGarden.Models.Entities
{
    public class Plant
    {
        public int Id { get; set; }

        public PlantType type { get; set; }

        public GardenBed location { get; set; }

        public DateTime datePlanted { get; set; }
    }
}
