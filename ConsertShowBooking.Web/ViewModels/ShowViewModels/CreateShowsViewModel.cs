using ConcertShowBooking_Entities;
using System.ComponentModel.DataAnnotations;

namespace ConsertShowBooking.Web.ViewModels.ShowViewModels
{
    public class CreateShowsViewModel
    {
        public string ShowName { get; set; }
        public string? Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime ShowDate { get; set; }
        public IFormFile ImageUrl { get; set; }

        public int VenueId { get; set; }
        public int ArtistId { get; set; }
    }
}
