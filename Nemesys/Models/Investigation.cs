namespace Nemesys.Models
{
    public class Investigation { 
        public int Id { get; set; }
        public string Description { get; set; }
        public int InvestigatorId { get; set; }
        public Investigator Investigator { get; set; }
        public int ReportId { get; set; }
        public Report Report { get; set; }

    }
}