using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace IcarufyGarden.Models.Entities
{
    public class GardenTask
    {

        public int Id { get; set; }

        public string Description { get; set; }

        public virtual ICollection<GardenBedsTasks> GardenBedTasks { get; set; }
    }
}
