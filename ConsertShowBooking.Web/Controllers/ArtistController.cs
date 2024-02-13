using ConcertShowBooking_Entities;
using ConcertShowBooking_Repositories.Implementations;
using ConcertShowBooking_Repositories.Interfaces;
using ConsertShowBooking.Web.ViewModels.ArtistViewModel;
using ConsertShowBooking.Web.ViewModels.ArtistViewModels;
using ConsertShowBooking.Web.ViewModels.VenueViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace ConsertShowBooking.Web.Controllers
{
    [Authorize(Roles ="Admin")]
    public class ArtistController : Controller
    {
        private readonly IUtilityRepo _UtilityRepo;
        private readonly IArtistRepo _ArtistRepo;
        private string containerName = "ArtistImage";
        public ArtistController(IArtistRepo artistRepo, IUtilityRepo repo)
        {
            _ArtistRepo = artistRepo;
            _UtilityRepo = repo;
        }

        public async Task<IActionResult> ArtistList()
        {
            List<ArtistViewModel> vm = new List<ArtistViewModel>();
            var artistList = await _ArtistRepo.GetAll();

            foreach (var artist in artistList)
            {
                vm.Add(new ArtistViewModel
                {
                    Id=artist.Id,
                    Name = artist.Name,
                    Bio = artist.Bio,
                    ImageUrl = artist.ImageUrl
                });
            }
            return View(vm);
        }
        public IActionResult InsertArtist()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> InsertArtist(CreateArtistViewModel vm)
        {
            var artist = new Artist
            {
                Name = vm.Name,
                Bio = vm.Bio
            };

            if (vm.ImageUrl != null)
            {
                // Save the image and get the URL
                artist.ImageUrl = await _UtilityRepo.SaveImage(containerName, vm.ImageUrl);
            }

            // Save the artist to the database
            await _ArtistRepo.Save(artist);

            return RedirectToAction("ArtistList");
        }

        public async Task<IActionResult> UpdateArtist(int id)
        {
            var artist = await _ArtistRepo.GetById(id);
            UpdateArtistViewModel vm = new UpdateArtistViewModel
            {
                Id = artist.Id,
                Name = artist.Name,
                Bio = artist.Bio,
              ImageUrl= artist.ImageUrl,
            
            };
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateArtist(UpdateArtistViewModel vm)
        {
          var artist =await _ArtistRepo.GetById(vm.Id);
            artist.Name = vm.Name;
            artist.Bio = vm.Bio;

            if (vm.ChooseImage != null)
            {
                var imageUrl = await _UtilityRepo.EditImage(containerName, vm.ChooseImage, artist.ImageUrl);
                if (imageUrl != null) 
                {
                    artist.ImageUrl = imageUrl;
                }
                else
                {
                    artist.ImageUrl = "/ArtistImage/default-image.jpg";

                }
            }
        
            await _ArtistRepo.Edit(artist);
            return RedirectToAction("ArtistList");
        }
        public async Task<IActionResult> RemoveArtist(int id)
        {
         var artist= await _ArtistRepo.GetById(id);
            await _ArtistRepo.Remove(artist);
            return RedirectToAction("ArtistList");
        }
    }
}
