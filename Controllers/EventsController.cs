using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using B_V__CLDV7111_.Data;
using B_V__CLDV7111_.Models;

namespace B_V__CLDV7111_.Controllers
{
	public class EventsController : Controller
	{
		private readonly ApplicationDbContext _context;
		public EventsController(ApplicationDbContext context) => _context = context;

		public async Task<IActionResult> Index()
		{
			var events = await _context.Events.Include(e => e.Venue).ToListAsync();
			return View(events);
		}

		public async Task<IActionResult> Details(int id)
		{
			var ev = await _context.Events.Include(e => e.Venue).FirstOrDefaultAsync(e => e.Id == id);
			if (ev == null) return NotFound();
			return View(ev);
		}

		public async Task<IActionResult> Create()
		{
			ViewBag.Venues = await _context.Venues.ToListAsync();
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(Event ev)
		{
			if (!ModelState.IsValid)
			{
				ViewBag.Venues = await _context.Venues.ToListAsync();
				return View(ev);
			}
			_context.Add(ev);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Edit(int id)
		{
			var ev = await _context.Events.FindAsync(id);
			if (ev == null) return NotFound();
			ViewBag.Venues = await _context.Venues.ToListAsync();
			return View(ev);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, Event ev)
		{
			if (id != ev.Id) return BadRequest();
			if (!ModelState.IsValid)
			{
				ViewBag.Venues = await _context.Venues.ToListAsync();
				return View(ev);
			}
			_context.Update(ev);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Delete(int id)
		{
			var ev = await _context.Events.FindAsync(id);
			if (ev == null) return NotFound();
			return View(ev);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var ev = await _context.Events.FindAsync(id);
			if (ev != null)
			{
				_context.Events.Remove(ev);
				await _context.SaveChangesAsync();
			}
			return RedirectToAction(nameof(Index));
		}
	}
}
