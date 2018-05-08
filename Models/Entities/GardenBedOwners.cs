
namespace IcarufyGarden.Models.Entities
{
    public class GardenBedOwners
    {
        public int Id { get; set; }

        public string OwnerId { get; set; }
        public AppUser Owner { get; set; }

        public int GardenBedId { get; set; }
        public GardenBed GardenBed { get; set; }
    }
}
