using ConcertShowBooking_Entities;
using ConcertShowBooking_Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ConsertBooking.Web.Controllers
{
    public class VenueController : Controller
    {
        private readonly IVenueRepo venueRepo;

        public VenueController(IVenueRepo _venueRepo)
        {
            this.venueRepo = _venueRepo;
        }
        public IActionResult VenueList()
        {
            var venues = venueRepo.GetAll();
            return View(venues);
        }
        public IActionResult InsertVenue()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult InsertVenue(Venue venue)
        {
            venueRepo.Save(venue);
            TempData["success"] = "Venue added";
            return View();
        }
        public IActionResult UpdateVenue(int Id)
        {
           var venue= venueRepo.GetById(Id);
            return View(venue);
        }
        [HttpPost]
        public IActionResult UpdateVenue(Venue venue)
        {
            venueRepo.Edit(venue);
            TempData["success"] = "Venue details updated";
            return RedirectToAction("VenueList");
        }
        public IActionResult RemoveVenue(int Id)
        {
            var venue = venueRepo.GetById(Id);
            return View(venue);
        }
        [HttpPost]
        public IActionResult RemoveVenue(Venue venue)
        {
            venueRepo.Remove(venue);
            TempData["success"] = "Venue details updated";
            return RedirectToAction("VenueList");
        }
    }
}
