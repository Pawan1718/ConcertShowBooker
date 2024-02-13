using ConcertShowBooking_Entities;
using ConcertShowBooking_Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertShowBooking_Repositories.Implementations
{
    public class TicketRepo : ITicketRepo
    {
        private readonly ApplicationDbContext context;

        public TicketRepo(ApplicationDbContext _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<int>> GetBookedTickets(int id)
        {
            var bookedTickets = await context.Tickets.Include(x=>x.Show)

                                            .Where(t => t.Booking.ShowId == id && t.isBooked)
                                            .Select(t => t.SeatNo)
                                            .ToListAsync();
            return bookedTickets;
        }

        public async Task<IEnumerable<Booking>> GetBooking(string userId)
        {
            var bookings = await context.Bookings
                .Where(x => x.UserId == userId)
                .Include(x => x.Tickets)
                .Include(x => x.Show).ToListAsync();
            return bookings;
        }
    }
}
