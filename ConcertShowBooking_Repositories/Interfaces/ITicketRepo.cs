using ConcertShowBooking_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertShowBooking_Repositories.Interfaces
{
    public interface ITicketRepo
    {
        Task<IEnumerable<int>> GetBookedTickets(int ShowId);
        Task<IEnumerable<Booking>> GetBooking(string userId);
    }
}
