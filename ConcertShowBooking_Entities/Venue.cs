using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertShowBooking_Entities
{
    public class Venue
    {
        public int Id { get; set; }
        public string VenueName { get; set; }
        public string Address { get; set; }
        public int SeatCapacity { get; set; }

        public ICollection<Show> Shows { get; set; } = new List<Show>();
    }
}
