using System.ComponentModel.DataAnnotations;

namespace ConsertShowBooking.Web.ViewModels.VenueViewModels
{
    public class VenueViewModel
    {
   
        public int Id { get; set; }
        public string VenueName { get; set; }
        public string Address { get; set; }
        public int SeatCapacity { get; set; }
    }
}
