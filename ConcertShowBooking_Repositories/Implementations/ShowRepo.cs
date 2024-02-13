using ConcertShowBooking_Entities;
using ConcertShowBooking_Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace ConcertShowBooking_Repositories.Implementations
{
    public class ShowRepo : IShowRepo
    {
        private readonly ApplicationDbContext context;

        public ShowRepo(ApplicationDbContext _context)
        {
            context = _context;
        }
        public async Task<Show> Edit(Show show)
        {
            context.Shows.Update(show);
            await context.SaveChangesAsync();
            return show;
        }

        public async Task<IEnumerable<Show>> GetAll()
        {
            var shows=await context.Shows.Include(s => s.Venue)
                            .Include(s => s.Artist)
                            .ToListAsync();

            return shows;
        }

        public async Task<Show> GetById(int id)
        {
            var show = await context.Shows
                 .Include(a=>a.Artist)
                 .Include(x => x.Venue)
                .FirstOrDefaultAsync(x=>x.Id==id);
            return show;
        }

        public async Task<Show> Remove(Show show)
        {
            context.Shows.Remove(show);
            await context.SaveChangesAsync();
            return show;

        }

        public async Task<Show> Save(Show show)
        {
            context.Shows.Add(show);
            await context.SaveChangesAsync();
            return show;
        }
      

    }
}
