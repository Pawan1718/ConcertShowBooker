using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcertShowBooking_Entities
{
    public class Show
    {
        public int Id { get; set; }
        public string ShowName { get; set; }
        public string?  Description { get; set; }
        public DateTime  ShowDate { get; set; }
        public string? ImageUrl { get; set; }

        public int VenueId { get; set; }
        public Venue Venue { get; set; }

        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
    }
}
