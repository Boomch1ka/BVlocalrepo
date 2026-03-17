using System;

namespace VenueBookingApp.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string CustomerName { get; set; }
        public DateTime BookingDate { get; set; }
    }
}