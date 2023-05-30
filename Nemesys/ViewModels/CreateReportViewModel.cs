using Nemesys.Models;

namespace Nemesys.ViewModels
{
    public class CreateReportViewModel
    {
        public DateTime DateOfReport { get; set; }
        public string Location { get; set; }
        public DateTime DateOfSpotting { get; set; }
        public List<HazardTypes> TypeOfHazard { get; set; }
        public string Description { get; set; }
        //public Reporter Reporter { get; set; }
        public string? ImageUrl { get; set; }
    }
}
