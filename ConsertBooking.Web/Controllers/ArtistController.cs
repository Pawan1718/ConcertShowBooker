using Microsoft.AspNetCore.Mvc;

namespace ConsertBooking.Web.Controllers
{
    public class ArtistController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
