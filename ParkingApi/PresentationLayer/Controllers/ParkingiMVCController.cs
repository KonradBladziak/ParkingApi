using BLL;
using DAL.Entity;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class ParkingiMVCController : Controller
    {
        private readonly IWorkService workService;

        public ParkingiMVCController(IWorkService workService)
        {
            this.workService = workService;
        }

        public IActionResult ZwrocParkingiWMiescie(int miastoId)
        {
            var result = this.workService.ZwrocParkingiWMiescie(miastoId).Result.ToArray();
            return View(result);
        }

        public IActionResult DodajParkingDoMiasta(int idParkingu, int idMiasta)
        {
            this.workService.DodajParkingDoMiasta(idParkingu, idMiasta);
            return View();
        }

        public IActionResult DodajParking(Parking parking, int iloscMiejsc, int iloscMiejscInwalidzkich, decimal rozmiarMiejscInwalidzkich)
        {
            this.workService.DodajParking(parking, iloscMiejsc, iloscMiejscInwalidzkich, rozmiarMiejscInwalidzkich);
            return View();
        }

        public IActionResult DodajOpiekunaDoParkingu(int idOpiekuna, int idParkingu)
        {
            this.workService.DodajOpiekunaDoParkingu(idOpiekuna, idParkingu);
            return View();
        }

        public IActionResult UsunParking(int idParkingu)
        {
            this.workService.UsunParking(idParkingu);
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
