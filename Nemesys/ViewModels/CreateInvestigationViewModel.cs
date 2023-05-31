using Microsoft.AspNetCore.Mvc;
using Nemesys.Models;
using System.ComponentModel.DataAnnotations;

namespace Nemesys.ViewModels
{
    public class CreateInvestigationViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 5)]
        public string Description { get; set; }
        public Investigator? Investigator { get; set; }
        public int ReportId { get; set; }
        public Report? Report { get; set; }
        public AuthorViewModel? Author { get; set; }

        [Required]
        public StatusTypes Status { get; set; }
        public List<StatusTypes>? Statuses { get; set; }
        public DateTime? LastUpdateDate { get; set; }
    }
}
