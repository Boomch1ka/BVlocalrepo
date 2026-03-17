using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace B_V__CLDV7111_.Models
{
	public class Booking
	{
		public int Id { get; set; }

		[ForeignKey("Event")]
		public int EventId { get; set; }
		public Event? Event { get; set; }

		[Required, EmailAddress]
		public string UserEmail { get; set; } = string.Empty;

		public int Seats { get; set; }

		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
	}
}
