namespace Nemesys.Models
{
    public class Investigation { 
        public int Id { get; set; }
        public string Description { get; set; }
        public Investigator Investigator { get; set; }
    }
}