using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class RezerwacjeMVCController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
