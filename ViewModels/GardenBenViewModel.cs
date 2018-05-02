using IcarufyGarden.Models.Entities;
using FluentValidation.Attributes;
using IcarufyGarden.ViewModels.Validations;
using System.Collections.Generic;

namespace IcarufyGarden.ViewModels
{
    public class GardenBenViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Plant> Plants { get; set; }
        public virtual ICollection<GardenBedsTaskViewModel> GardenBedTasks { get; set; }
    }

    public class GardenBedsTaskViewModel
    {
        public int Id { get; set; }
        public string description { get; set; }
        public virtual ICollection<ChildGardenBedViewModel> taskGardenBeds { get; set; }

    }
    
    public class ChildGardenBedViewModel
    {
        public int Id { get; set; }
        public string description { get; set; }
    }
}
