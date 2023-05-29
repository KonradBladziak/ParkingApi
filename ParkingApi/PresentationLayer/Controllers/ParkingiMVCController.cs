using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class ParkingiMVCController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
