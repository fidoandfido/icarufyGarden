using FluentValidation.Attributes;
using IcarufyGarden.Models.Validations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace IcarufyGarden.Models.Entities
{


    [Validator(typeof(GardenBedModelValidator))]
    public class GardenBed
    {

        public int Id { get; set; }

        public AppUser creator { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Plant> Plants { get; set; }

        public virtual ICollection<GardenBedsTasks> GardenBedTasks { get; set; }

        public virtual ICollection<GardenBedOwners>  Owners { get; set; }

    }
}
