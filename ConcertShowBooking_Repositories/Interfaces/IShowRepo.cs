using ConcertShowBooking_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertShowBooking_Repositories.Interfaces
{
    public interface IShowRepo
    {
        Task<IEnumerable<Show>> GetAll();
        Task<Show> GetById(int id);
        Task<Show> Save(Show show);
        Task<Show> Edit(Show show);
        Task<Show> Remove(Show show);
    }
}
