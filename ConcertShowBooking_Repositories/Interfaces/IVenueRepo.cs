using ConcertShowBooking_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertShowBooking_Repositories.Interfaces
{
    public interface IVenueRepo
    {
        Task<IEnumerable<Venue>> GetAll();
        Task<Venue> GetById(int Id);
        Task<Venue> Save(Venue venue);
        Task<Venue>Edit(Venue venue);
        Task<Venue>Remove(Venue venue);
    }
}
