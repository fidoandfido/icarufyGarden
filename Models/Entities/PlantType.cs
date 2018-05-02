using System;
using System.ComponentModel.DataAnnotations;

namespace IcarufyGarden.Models.Entities
{
    public class PlantType
    {

        public int Id { get; set; }

        [Required]
        public string CommonName { get; set; }

        [Required]
        public string ScientificName { get; set; }


    }
}
