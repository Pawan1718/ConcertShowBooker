namespace ConsertShowBooking.Web.ViewModels.ArtistViewModels
{
    public class UpdateArtistViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile ChooseImage { get; set; }
    }
}
