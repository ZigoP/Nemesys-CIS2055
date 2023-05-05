namespace Nemesys.Models
{
    public class Report
    {
        public int Id { get; set; }
        public DateTime DateOfReport { get; set; }
        public string Location { get; set; }
        public DateTime DateOfSpotting { get; set; }
        public string TypeOfHazard { get; set; }
        public string Description { get; set; }
        public Enum status { get; set; }
        public Reporter Reporter { get; set; }
        public string ImageUrl { get; set; }
        public int UpVotes { get; set; }
        public Investigation Investigation { get; set; }

    }
}