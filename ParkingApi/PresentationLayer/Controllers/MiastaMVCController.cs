using BLL;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class MiastaMVCController : Controller
    {
        private readonly IWorkService workService;

        public MiastaMVCController(IWorkService workService)
        {
            this.workService = workService;
        }

        public IActionResult DodajMiasto(string nazwa, string wojewodztwo)
        {
            this.workService.DodajMiasto(nazwa, wojewodztwo);
            return View();
        }

        public IActionResult UsunMiasto(int idMiasta)
        {
            this.workService.UsunMiasto(idMiasta);
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
