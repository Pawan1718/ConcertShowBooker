using ConcertShowBooking_Entities;

namespace ConsertShowBooking.Web.ViewModels.HomeViewModels
{
    public class AvailableTicketViewModel
    {
        public int ShowId { get; set; }
        public string ShowName { get; set; }
        public List<int>SeatsAvailability { get; set; }
    }
}
