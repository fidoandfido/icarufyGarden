using IcarufyGarden.Models.Entities;
using FluentValidation.Attributes;
using IcarufyGarden.ViewModels.Validations;
using System.Collections.Generic;

namespace IcarufyGarden.ViewModels
{
    public class GardenBedViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Plant> Plants { get; set; }
        public virtual ICollection<GardenBedsTaskViewModel> GardenBedTasks { get; set; }
        public virtual ICollection<GardenBedOwnerViewModel> Owners { get; set; }
    }

    public class GardenBedOwnerViewModel
    {
        public string Id { get; set; }
        public string userName { get; set; }
        public string firstName { get; set; }
        public string secondName { get; set; }
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
