using Nemesys.Models;

namespace Nemesys.ViewModels
{
    public class InvestigationViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Investigator Investigator { get; set; }
        public AuthorViewModel? Author { get; set; }

    }
}
