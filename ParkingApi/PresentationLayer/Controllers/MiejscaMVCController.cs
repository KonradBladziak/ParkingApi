using BLL;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class MiejscaMVCController : Controller
    {
        private readonly IWorkService workService;

        public MiejscaMVCController(IWorkService workService)
        {
            this.workService = workService;
        }

        public IActionResult DodajMiejsca(int ilosc, int idParkingu)
        {
            this.workService.DodajMiejsca(ilosc, idParkingu);
            return View();
        }

        public IActionResult DodajMiejscaInwalidzkie(int ilosc, int idParkingu, decimal rozmiarMiejsca)
        {
            this.workService.DodajMiejscaInwalidzkie(ilosc, idParkingu, rozmiarMiejsca);
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
