namespace ConsertShowBooking.Web.ViewModels.HomeViewModels
{
    public class ShowsDetailsViewModel
    {
        public int ShowId { get; set; }
        public string ShowName { get; set; }
        public DateTime ShowDate { get; set; }
        public string? showsImage { get; set; }
        public string? Description { get; set; }
        public string ArtistName { get; set; }
        public string ArtistImage { get; set; }
        public string VenueName { get; set;}
        public string VenueAddress { get; set; }

    }
}
