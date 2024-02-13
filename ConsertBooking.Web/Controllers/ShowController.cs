using Microsoft.AspNetCore.Mvc;

namespace ConsertBooking.Web.Controllers
{
    public class ShowController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
