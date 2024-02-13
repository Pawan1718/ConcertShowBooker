using ConcertShowBooking_Entities;
using ConcertShowBooking_Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertShowBooking_Repositories.Implementations
{
    public class BookingRepo : IBookingRepo
    {
        private readonly ApplicationDbContext _context;

        public BookingRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Booking(Booking booking)
        {
            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Booking>> GetAll(int ShowId)
        {
            var bookings = await _context.Bookings
                .Include(x => x.Tickets)
                .Include(s => s.User)
                .Where(c => c.ShowId == ShowId)
                .ToListAsync();
            return bookings;
        }



    }
}
