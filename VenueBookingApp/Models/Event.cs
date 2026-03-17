using System;

namespace VenueBookingApp.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public int VenueId { get; set; }
        public string ImageUrl { get; set; } = "https://via.placeholder.com/150"; // Placeholder URL for images
    }
}