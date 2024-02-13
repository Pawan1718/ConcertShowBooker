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
    public class ArtistRepo : IArtistRepo
    {
        private readonly ApplicationDbContext _context;

        public ArtistRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Artist> Edit(Artist artist)
        {
            _context.Artists.Update(artist);
            await _context.SaveChangesAsync();
            return artist;
        }

        public async Task<IEnumerable<Artist>> GetAll()
        {
            var artists = await _context.Artists.ToListAsync();
            return artists;
        }

        public async Task<Artist> GetById(int Id)
        {
            var artist = await _context.Artists.FindAsync(Id);
            return artist;
        }

        public async Task<Artist> Remove(Artist artist)
        {
            _context.Artists.Remove(artist);
            await _context.SaveChangesAsync();
            return artist;
        }

        public async Task<Artist> Save(Artist artist)
        {
            _context.Artists.Add(artist);
            await _context.SaveChangesAsync();
            return artist;
        }
    }
}
