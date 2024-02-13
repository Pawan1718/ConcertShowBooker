using ConcertShowBooking_Entities;

namespace ConsertShowBooking.Web.ViewModels.ShowViewModels
{
    public class ShowListViewModel
    {
        public int Id { get; set; }
        public string ShowName { get; set; }
        public DateTime ShowDate { get; set; }
        public string VenueName { get; set; }
        public string ArtistName { get; set; }
    }
}
