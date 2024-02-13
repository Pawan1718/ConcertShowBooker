namespace ConsertShowBooking.Web.ViewModels.ShowViewModels
{
    public class UpdateShowViewModel
    {
        public int Id { get; set; }
        public string ShowName { get; set; }
        public string? Description { get; set; }
        public DateTime ShowDate { get; set; }
        public string? ImageUrl { get; set; }
        public IFormFile ChooesFile { get; set; }

        public int VenueId { get; set; }
        public int ArtistId { get; set; }
    }
}
