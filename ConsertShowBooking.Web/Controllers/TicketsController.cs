using ConcertShowBooking_Repositories.Interfaces;
using ConsertShowBooking.Web.ViewModels.TicketsViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ConsertShowBooking.Web.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ITicketRepo ticketRepo;

        public TicketsController(ITicketRepo ticketRepo)
        {
            this.ticketRepo = ticketRepo;
        }
        public async Task<IActionResult> MyTickets()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var userId = claim.Value;

            var bookings = await ticketRepo.GetBooking(userId);
            List<BookingViewModel> vm = new List<BookingViewModel>();
            foreach (var booking in bookings)
            {
                vm.Add(new BookingViewModel
                {
                    BookingId = booking.BookingId,
                    BookingDate = booking.BookingDate,
                    ShowName = booking.Show.ShowName,
                    ShowImage=booking.Show.ImageUrl,
                    ShowDate=booking.Show.ShowDate,
                    
                    Tickets = booking.Tickets.Select(ticketVM => new TicketsViewModel
                    {
                        SeatNo = ticketVM.SeatNo,
                    }).ToList(),
                });
            }

            // Check if there are no bookings
            if (vm.Count == 0)
            {
                return NotFound();
            }

            return View(vm);
        }
    }
}
