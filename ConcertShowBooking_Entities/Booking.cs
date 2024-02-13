using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertShowBooking_Entities
{
    public class Booking
    {
        public int BookingId { get; set; }
        public DateTime BookingDate { get; set; }


        [ForeignKey(nameof(Show))]
        public int ShowId { get; set; }
        public Show Show { get; set; }


        public string? UserId { get; set; }
        public  ApplicationUser User { get; set; }


        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
