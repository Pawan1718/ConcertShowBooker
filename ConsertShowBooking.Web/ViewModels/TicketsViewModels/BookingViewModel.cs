namespace ConsertShowBooking.Web.ViewModels.TicketsViewModels
{
    public class BookingViewModel
    {
        public int BookingId { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime ShowDate { get; set; }
        public string ShowName { get; set; }
        public string ShowImage { get; set; }


        public List<TicketsViewModel>Tickets { get; set; }
    }
}
