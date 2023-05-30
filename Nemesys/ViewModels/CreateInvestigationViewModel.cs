using Microsoft.AspNetCore.Mvc;
using Nemesys.Models;

namespace Nemesys.ViewModels
{
    public class CreateInvestigationViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Investigator? Investigator { get; set; }
        public int ReportId { get; set; }
        public Report? Report { get; set; }
        public AuthorViewModel? Author { get; set; }
        public StatusTypes Status { get; set; }
        public List<StatusTypes>? Statuses { get; set; }
    }
}
