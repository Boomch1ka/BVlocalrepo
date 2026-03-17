using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using B_V__CLDV7111_.Data;
using B_V__CLDV7111_.Models;

namespace B_V__CLDV7111_.Controllers
{
	public class VenuesController : Controller
	{
		private readonly ApplicationDbContext _context;
		public VenuesController(ApplicationDbContext context) => _context = context;

		public async Task<IActionResult> Index()
		{
			var list = await _context.Venues.ToListAsync();
			return View(list);
		}

		public async Task<IActionResult> Details(int id)
		{
			var venue = await _context.Venues.FindAsync(id);
			if (venue == null) return NotFound();
			return View(venue);
		}

		public IActionResult Create() => View();

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(Venue venue)
		{
			if (!ModelState.IsValid) return View(venue);
			_context.Add(venue);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Edit(int id)
		{
			var venue = await _context.Venues.FindAsync(id);
			if (venue == null) return NotFound();
			return View(venue);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, Venue venue)
		{
			if (id != venue.Id) return BadRequest();
			if (!ModelState.IsValid) return View(venue);

			_context.Update(venue);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Delete(int id)
		{
			var venue = await _context.Venues.FindAsync(id);
			if (venue == null) return NotFound();
			return View(venue);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var venue = await _context.Venues.FindAsync(id);
			if (venue != null)
			{
				_context.Venues.Remove(venue);
				await _context.SaveChangesAsync();
			}
			return RedirectToAction(nameof(Index));
		}
	}
}
