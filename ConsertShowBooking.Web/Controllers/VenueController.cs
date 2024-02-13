using ConcertShowBooking_Entities;
using ConcertShowBooking_Repositories.Implementations;
using ConcertShowBooking_Repositories.Interfaces;
using ConsertShowBooking.Web.ViewModels.VenueViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ConsertShowBooking.Web.Controllers
{
    public class VenueController : Controller
    {
        private readonly IVenueRepo venueRepo;

        public VenueController(IVenueRepo _venueRepo)
        {
            venueRepo = _venueRepo;
        }
        public async Task<IActionResult> VenueList()
        {
            List<VenueViewModel> vm = new List<VenueViewModel>();
            var venueList = await venueRepo.GetAll();
            foreach (var venue in venueList)
            {
                vm.Add(new VenueViewModel
                {
                    Id=venue.Id,
                    VenueName = venue.VenueName,
                    Address = venue.Address,
                    SeatCapacity = venue.SeatCapacity,
                });
            }
            return View(vm);
        }
        public IActionResult InsertVenue()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> InsertVenue(CreateVenueViewModel vm)
        {
            var venue = new Venue
            {
                VenueName = vm.VenueName,
                Address = vm.Address,
                SeatCapacity = vm.SeatCapacity,
            };
            await venueRepo.Save(venue);
            return RedirectToAction("VenueList");
        }
        public async Task<IActionResult> UpdateVenue(int id)
        {
            var venue = await venueRepo.GetById(id);

            if (venue == null)
            {
                return NotFound();
            }

            UpdateVenueViewModel vm = new UpdateVenueViewModel
            {
                Id = venue.Id,
                VenueName = venue.VenueName,
                Address = venue.Address,
                SeatCapacity = venue.SeatCapacity
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateVenue(UpdateVenueViewModel vm)
        {
            var venue = new Venue
            {
                Id= vm.Id,
                VenueName= vm.VenueName,
                Address = vm.Address,
                SeatCapacity = vm.SeatCapacity,

            };
            await venueRepo.Edit(venue);
            return RedirectToAction("VenueList");
        }
        public async Task<IActionResult> RemoveVenue(int id)
        {
            var venue = await venueRepo.GetById(id);
            RemoveVenueViewModel vm = new RemoveVenueViewModel
            {
                Id = venue.Id,
                VenueName = venue.VenueName,
                Address = venue.Address,
                SeatCapacity = venue.SeatCapacity
            };
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> RemoveVenue(RemoveVenueViewModel vm)
        {
            var venue = new Venue
            {
                Id = vm.Id,
                VenueName = vm.VenueName,
                Address = vm.Address,
                SeatCapacity = vm.SeatCapacity
            };
            await venueRepo.Remove(venue);
            return RedirectToAction("VenueList");
        }
    }
}
