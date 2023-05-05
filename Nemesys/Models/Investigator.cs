namespace Nemesys.Models
{
	public class Investigator
	{
		public User User { get; set; }
		public List<Investigation> Investigations { get; set; }
	}
}