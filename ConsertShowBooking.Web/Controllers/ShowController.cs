using ConcertShowBooking_Entities;
using ConcertShowBooking_Repositories.Implementations;
using ConcertShowBooking_Repositories.Interfaces;
using ConsertShowBooking.Web.ViewModels.DashboardViewModels;
using ConsertShowBooking.Web.ViewModels.ShowViewModels;
using ConsertShowBooking.Web.ViewModels.VenueViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ConsertShowBooking.Web.Controllers
{
    public class ShowController : Controller
    {
        private readonly IBookingRepo _bookingRepo;
        private readonly IShowRepo _showRepo;
        private readonly IVenueRepo _venueRepo;
        private readonly IUtilityRepo _utilityRepo;
        private readonly IArtistRepo _artistRepo;
        private string containerName = "ShowImage";

        public ShowController(IShowRepo showRepo, IVenueRepo venueRepo, IUtilityRepo utilityRepo, IArtistRepo artistRepo, IBookingRepo bookingRepo)
        {
            _showRepo = showRepo;
            _venueRepo = venueRepo;
            _utilityRepo = utilityRepo;
            _artistRepo = artistRepo;
            _bookingRepo = bookingRepo;
        }


        public async Task<IActionResult> ShowsList()
        {
            var showsList = await _showRepo.GetAll();
            var vm = new List<ShowListViewModel>();
            foreach (var show in showsList)
            {
                vm.Add(new ShowListViewModel
                {
                    Id= show.Id,
                    ShowName = show.ShowName,
                    ShowDate=show.ShowDate,
                    ArtistName=show.Artist.Name,
                    VenueName=show.Venue.VenueName
                });
            }
            return View(vm);
        }
      
        public async Task<IActionResult> InsertShow()
        {
            var artist = await _artistRepo.GetAll();
            var venue = await _venueRepo.GetAll();
            ViewBag.artistList = new SelectList(artist, "Id", "Name");
            ViewBag.venueList = new SelectList(venue, "Id", "VenueName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> InsertShow(CreateShowsViewModel vm)
        {
            var show = new Show
            {
             ShowDate=vm.ShowDate,
             ShowName=vm.ShowName,
             Description=vm.Description,
             ArtistId=vm.ArtistId,
             VenueId=vm.VenueId,
            };
            if (vm.ImageUrl != null)
            {
                show.ImageUrl = await _utilityRepo.SaveImage(containerName, vm.ImageUrl);
            }
            await _showRepo.Save(show);
            return RedirectToAction("ShowsList");
        }
        public async Task<IActionResult> UpdateShow(int id)
        {
            var show = await _showRepo.GetById(id);
            var artist = await _artistRepo.GetAll();
            var venue = await _venueRepo.GetAll();
            ViewBag.artistList = new SelectList(artist, "Id", "Name");
            ViewBag.venueList = new SelectList(venue, "Id", "VenueName");
            UpdateShowViewModel vm = new UpdateShowViewModel
            {
                Id = show.Id,
                ShowName = show.ShowName,
                Description = show.Description,
                ImageUrl = show.ImageUrl,
                ShowDate=show.ShowDate,
                ArtistId=show.ArtistId,
                VenueId=show.VenueId,
            };
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateShow(UpdateShowViewModel vm)
        {
            var _show= await _showRepo.GetById(vm.Id);

            _show.Id = vm.Id;
            _show.ShowDate = vm.ShowDate;
            _show.ShowName = vm.ShowName;
            _show.Description = vm.Description;
            _show.VenueId = vm.VenueId;
            _show.ArtistId = vm.ArtistId;
            
            if (vm.ImageUrl!=null)
            {
                _show.ImageUrl = await _utilityRepo.EditImage(containerName,vm.ChooesFile, _show.ImageUrl);
            }
            await _showRepo.Edit(_show);
            return RedirectToAction("ShowsList");
        }

        public async Task<IActionResult> GetTickets(int id)
        {
            var bookings = await _bookingRepo.GetAll(id);

            if (bookings == null)
            {
                return NotFound();
            }

            var vm = bookings.Select(b => new DashboardTicketViewModel
            {
                UserName = b.User?.UserName ?? "Unknown",
                ShowName = b.Show?.ShowName ?? "Unknown",
                SeatNo = string.Join(",", b.Tickets.Select(t => t.SeatNo))
            }).ToList();

            return View(vm);
        }

    }
}

