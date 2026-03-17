using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using B_V__CLDV7111_.Models;

namespace B_V__CLDV7111_.Data
{
	public static class DbInitializer
	{
		public static async Task InitializeAsync(IServiceProvider serviceProvider)
		{
			var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
			// Ensure the database is created (including Identity tables) before seeding.
			await context.Database.EnsureCreatedAsync();

			if (await context.Venues.AnyAsync()) return;

			var v1 = new Venue
			{
				Name = "Oceanview Hall",
				Address = "123 Beach Ave",
				ImageUrl = "https://via.placeholder.com/600x400.png?text=Oceanview+Hall"
			};
			var v2 = new Venue
			{
				Name = "City Conference Center",
				Address = "456 Main St",
				ImageUrl = "https://via.placeholder.com/600x400.png?text=City+Conference+Center"
			};

			context.Venues.AddRange(v1, v2);
			await context.SaveChangesAsync();

			var e1 = new Event
			{
				Name = "Summer Music Festival",
				Description = "A day of live music.",
				StartDate = DateTime.UtcNow.AddDays(30),
				EndDate = DateTime.UtcNow.AddDays(30).AddHours(6),
				ImageUrl = "https://via.placeholder.com/600x400.png?text=Music+Festival",
				VenueId = v1.Id
			};
			var e2 = new Event
			{
				Name = "Tech Meetup",
				Description = "Local tech talks and networking.",
				StartDate = DateTime.UtcNow.AddDays(10),
				EndDate = DateTime.UtcNow.AddDays(10).AddHours(3),
				ImageUrl = "https://via.placeholder.com/600x400.png?text=Tech+Meetup",
				VenueId = v2.Id
			};

			context.Events.AddRange(e1, e2);
			await context.SaveChangesAsync();
		}
	}
}
