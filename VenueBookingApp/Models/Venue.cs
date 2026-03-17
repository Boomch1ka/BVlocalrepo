namespace VenueBookingApp.Models
{
    public class Venue
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string ImageUrl { get; set; } = "https://via.placeholder.com/150";
    }
}