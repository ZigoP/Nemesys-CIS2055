using Nemesys.Models;

namespace Nemesys.ViewModels
{
    public class CreateReportViewModel
    {
        //public DateTime DateOfReport { get; set; }
        public string Location { get; set; }
        public DateTime DateOfSpotting { get; set; }
        public HazardTypes TypeOfHazard { get; set; }
        public List<HazardTypes>? TypeOfHazards { get; set; }
        public string Description { get; set; }
        //public Reporter Reporter { get; set; }
        public string? ImageUrl { get; set; }
        public IFormFile? ImageToUpload { get; set; } //used only when submitting form

    }
}
