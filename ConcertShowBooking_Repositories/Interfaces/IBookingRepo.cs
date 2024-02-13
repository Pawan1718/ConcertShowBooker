using ConcertShowBooking_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertShowBooking_Repositories.Interfaces
{
    public interface IBookingRepo
    {
        Task Booking(Booking booking);
        Task<IEnumerable<Booking>> GetAll(int ShowId);
    }
}
