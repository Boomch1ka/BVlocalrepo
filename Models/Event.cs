using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace B_V__CLDV7111_.Models
{
	public class Event
	{
		public int Id { get; set; }

		[Required]
		public string Name { get; set; } = string.Empty;

		public string? Description { get; set; }

		[Display(Name = "Start Date")]
		public DateTime StartDate { get; set; }

		[Display(Name = "End Date")]
		public DateTime EndDate { get; set; }

		[Display(Name = "Image URL")]
		public string? ImageUrl { get; set; }

		[ForeignKey("Venue")]
		public int VenueId { get; set; }
		public Venue? Venue { get; set; }
	}
}
