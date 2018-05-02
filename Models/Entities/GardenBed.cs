using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace IcarufyGarden.Models.Entities
{
    public class GardenBed
    {
        
        public int Id { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Plant> Plants { get; set; }

        public virtual ICollection<GardenBedsTasks> GardenBedTasks { get; set; }
    }
}
