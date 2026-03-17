using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using VenueBookingApp.Models;

namespace VenueBookingApp.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>() ))
            {
                // Check if the database has been seeded
                if (context.Venues.Any() || context.Events.Any() || context.Bookings.Any())
                {
                    return;   // DB has been seeded
                }

                var venues = new List<Venue>
                {
                    new Venue { Name = "Venue One", Location = "Location One", ImageUrl = "https://via.placeholder.com/150" },
                    new Venue { Name = "Venue Two", Location = "Location Two", ImageUrl = "https://via.placeholder.com/150" }
                };

                context.Venues.AddRange(venues);
                context.SaveChanges();

                var events = new List<Event>
                {
                    new Event { Title = "Event One", Date = DateTime.Now.AddDays(30), VenueId = venues[0].Id, ImageUrl = "https://via.placeholder.com/150" },
                    new Event { Title = "Event Two", Date = DateTime.Now.AddDays(60), VenueId = venues[1].Id, ImageUrl = "https://via.placeholder.com/150" }
                };

                context.Events.AddRange(events);
                context.SaveChanges();

                var bookings = new List<Booking>
                {
                    new Booking { EventId = events[0].Id, CustomerName = "John Doe", BookingDate = DateTime.Now },
                    new Booking { EventId = events[1].Id, CustomerName = "Jane Smith", BookingDate = DateTime.Now }
                };

                context.Bookings.AddRange(bookings);
                context.SaveChanges();
            }
        }
    }
}