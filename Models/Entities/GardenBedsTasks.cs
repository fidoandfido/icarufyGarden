
namespace IcarufyGarden.Models.Entities
{
    public class GardenBedsTasks
    {
        public int Id { get; set; }
        public int GardenBedId { get; set; }
        public int TaskId { get; set; }
        public GardenTask GardenTask{ get; set; }
        public GardenBed GardenBed{ get; set; }
    }
}
