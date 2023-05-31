using Nemesys.Models;
using System.ComponentModel.DataAnnotations;

namespace Nemesys.ViewModels
{
    public class CreateReportViewModel
    {
        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        public string Location { get; set; }

        [Required]
        public DateTime DateOfSpotting { get; set; }

        [Required]
        public HazardTypes TypeOfHazard { get; set; }
        public List<HazardTypes>? TypeOfHazards { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 5)]
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
        public IFormFile? ImageToUpload { get; set; }

        public DateTime? LastUpdateDate { get; set; }

    }
}
