using Microsoft.AspNetCore.Mvc;
using VenueBookingApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace VenueBookingApp.Controllers
{
    public class VenuesController : Controller
    {
        private static List<Venue> venues = new List<Venue>
        {
            new Venue { Id = 1, Name = "Venue One", Location = "Location One", ImageUrl = "https://via.placeholder.com/150" },
            new Venue { Id = 2, Name = "Venue Two", Location = "Location Two", ImageUrl = "https://via.placeholder.com/150" }
        };

        public IActionResult Index()
        {
            return View(venues);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Venue venue)
        {
            if (ModelState.IsValid)
            {
                venue.Id = venues.Max(v => v.Id) + 1;
                venues.Add(venue);
                return RedirectToAction(nameof(Index));
            }
            return View(venue);
        }

        public IActionResult Edit(int id)
        {
            var venue = venues.FirstOrDefault(v => v.Id == id);
            if (venue == null)
            {
                return NotFound();
            }
            return View(venue);
        }

        [HttpPost]
        public IActionResult Edit(Venue venue)
        {
            if (ModelState.IsValid)
            {
                var existingVenue = venues.FirstOrDefault(v => v.Id == venue.Id);
                if (existingVenue != null)
                {
                    existingVenue.Name = venue.Name;
                    existingVenue.Location = venue.Location;
                    existingVenue.ImageUrl = venue.ImageUrl;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(venue);
        }

        public IActionResult Details(int id)
        {
            var venue = venues.FirstOrDefault(v => v.Id == id);
            if (venue == null)
            {
                return NotFound();
            }
            return View(venue);
        }

        public IActionResult Delete(int id)
        {
            var venue = venues.FirstOrDefault(v => v.Id == id);
            if (venue == null)
            {
                return NotFound();
            }
            return View(venue);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var venue = venues.FirstOrDefault(v => v.Id == id);
            if (venue != null)
            {
                venues.Remove(venue);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}