using Nemesys.Models;

namespace Nemesys.ViewModels
{
    public class ReportViewModel
    {
        public int Id { get; set; }
        public DateTime DateOfReport { get; set; }
        public string Location { get; set; }
        public DateTime DateOfSpotting { get; set; }
        public HazardTypes TypeOfHazard { get; set; }
        public string Description { get; set; }
        public StatusTypes Status { get; set; }
        public Reporter Reporter { get; set; }
        public string? ImageUrl { get; set; }
        public int UpVotes { get; set; }
        public Investigation? Investigation { get; set; }
        public AuthorViewModel? Author { get; set; }

    }
}
