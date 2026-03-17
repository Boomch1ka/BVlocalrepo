using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using B_V__CLDV7111_.Data;
using B_V__CLDV7111_.Models;

namespace B_V__CLDV7111_.Controllers
{
	[Authorize]
	public class BookingsController : Controller
	{
		private readonly ApplicationDbContext _context;
		public BookingsController(ApplicationDbContext context) => _context = context;

		public async Task<IActionResult> Index()
		{
			var bookings = await _context.Bookings.Include(b => b.Event).ThenInclude(e => e.Venue).ToListAsync();
			return View(bookings);
		}

		public async Task<IActionResult> Create(int? eventId)
		{
			if (eventId == null) return BadRequest();
			var ev = await _context.Events.Include(e => e.Venue).FirstOrDefaultAsync(e => e.Id == eventId);
			if (ev == null) return NotFound();
			ViewBag.Event = ev;
			var booking = new Booking { EventId = ev.Id };
			return View(booking);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(Booking booking)
		{
			if (!ModelState.IsValid) return View(booking);

			// Store the user email from the logged-in identity.
			booking.UserEmail = User?.Identity?.Name ?? booking.UserEmail;
			booking.CreatedAt = DateTime.UtcNow;
			_context.Add(booking);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}
	}
}
