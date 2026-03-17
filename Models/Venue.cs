using System.ComponentModel.DataAnnotations;

namespace B_V__CLDV7111_.Models
{
	public class Venue
	{
		public int Id { get; set; }

		[Required]
		public string Name { get; set; } = string.Empty;

		public string? Address { get; set; }

		[Display(Name = "Image URL")]
		public string? ImageUrl { get; set; }
	}
}
