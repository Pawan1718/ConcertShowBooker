using ConcertShowBooking_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertShowBooking_Repositories.Interfaces
{
    public interface IArtistRepo
    {
        Task<IEnumerable<Artist>> GetAll();
        Task<Artist> GetById(int Id);
        Task<Artist> Save(Artist artist);
        Task<Artist> Edit(Artist artist);
        Task<Artist> Remove(Artist artist);
    }
}
