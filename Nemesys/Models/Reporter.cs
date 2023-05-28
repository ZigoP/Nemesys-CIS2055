using System.ComponentModel.DataAnnotations.Schema;

namespace Nemesys.Models
{
    public class Reporter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<Report> Reports { get; set; }
        public int ReportersRanking { get; set; }
    }
}