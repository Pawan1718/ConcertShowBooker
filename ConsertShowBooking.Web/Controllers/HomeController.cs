using ConcertShowBooking_Entities;
using ConcertShowBooking_Repositories.Interfaces;
using ConsertShowBooking.Web.Models;
using ConsertShowBooking.Web.ViewModels.HomeViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace ConsertShowBooking.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IShowRepo _showRepo;
        private readonly ITicketRepo _ticketRepo;
        private readonly IVenueRepo _venueRepo;
        private readonly IBookingRepo _bookingRepo;

        public HomeController(ILogger<HomeController> logger, IShowRepo showRepo, ITicketRepo ticketRepo, IVenueRepo venueRepo, IBookingRepo bookingRepo)
        {
            _logger = logger;
            _showRepo = showRepo;
            _ticketRepo = ticketRepo;
            _venueRepo = venueRepo;
            _bookingRepo = bookingRepo;
        }

        public async Task<IActionResult> Index()
        {
            DateTime today = DateTime.Today;
            var shows = await _showRepo.GetAll();
            var vm = shows.Where(x => x.ShowDate.Date >= today).Select(s => new HomeViewModel
            {
                ShowId = s.Id,
                ShowName = s.ShowName,
                ArtistName = s.Artist.Name,
                showsImage = s.ImageUrl,
                Description = s.Description.Length > 100 ? s.Description.Substring(0, 100) : s.Description
            }).ToList();

            return View(vm); 
        }
        public async Task<IActionResult> ShowsDetails(int id)
        {
            var showDetails = await _showRepo.GetById(id);
            if (showDetails == null)
            {
                return NotFound();
            }
            var vm = new ShowsDetailsViewModel
            {
                ShowId = showDetails.Id,
                Description = showDetails.Description,
                ShowName = showDetails.ShowName,
                ArtistName = showDetails.Artist.Name,
                ShowDate = showDetails.ShowDate,
                showsImage = showDetails.ImageUrl,
                VenueAddress = showDetails.Venue.Address,
                VenueName = showDetails.Venue.VenueName,
                ArtistImage = showDetails.Artist.ImageUrl,
            };
            return View(vm);
        }
        [Authorize]
        public async Task<IActionResult> TicketAvailability(int id)
        {
            var show = await _showRepo.GetById(id);
            if (show == null)
            {
                return NotFound();
            }
            var allSeats = Enumerable.Range(1, show.Venue.SeatCapacity).ToList();
            var bookedTickets = await _ticketRepo.GetBookedTickets(show.Id);
            var seatAvail = allSeats.Except(bookedTickets).ToList();


            var vm = new AvailableTicketViewModel
            {
                ShowId = show.Id,
                ShowName = show.ShowName,
                SeatsAvailability = seatAvail
            };
            return View(vm);
           
        }
      
        public async Task<IActionResult> BookTickets(int ShowId,List<int> SelectedSeats)
        {
            if (SelectedSeats==null || SelectedSeats.Count==0)
            {
                ModelState.AddModelError("", "Seats Not Selected");
                return RedirectToAction("TicketAvailability", new { id = ShowId });
            }
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var userId = claim.Value;

          
            var newBooking = new Booking
            {
                ShowId = ShowId,
                BookingDate = DateTime.Now,
                UserId=userId
            };
            foreach (var seatNo in SelectedSeats)
            {
                newBooking.Tickets.Add(new Ticket
                {
                    SeatNo= seatNo,
                    isBooked=true,
                    Show= await _showRepo.GetById(ShowId)
                });
            }
            await _bookingRepo.Booking(newBooking);
         
            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}