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
    public class VenueRepo : IVenueRepo
    {
        private readonly ApplicationDbContext _context;

        public VenueRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Venue> Edit(Venue venue)
        {
            _context.Venues.Update(venue);
            await _context.SaveChangesAsync();
            return venue;
        }

        public async Task<IEnumerable<Venue>> GetAll()
        {
            var venues = await _context.Venues.ToListAsync();
            return venues;
        }

        public async Task<Venue> GetById(int id)
        {
            var venue = await _context.Venues.FindAsync(id);
            return venue;
        }


        public async Task<Venue> Remove(Venue venue)
        {
            _context.Venues.Remove(venue);
            await _context.SaveChangesAsync();
            return venue;
        }

        public async Task<Venue> Save(Venue venue)
        {
            _context.Venues.Add(venue);
            await _context.SaveChangesAsync();
            return venue;
        }

    }
}
