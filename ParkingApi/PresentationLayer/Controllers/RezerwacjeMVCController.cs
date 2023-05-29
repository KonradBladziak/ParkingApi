using BLL;
using DAL.Entity;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class RezerwacjeMVCController : Controller
    {
        private readonly IWorkService workService;
        public RezerwacjeMVCController(IWorkService workService)
        {
            this.workService = workService;
        }

        public IActionResult DodajRezerwacje(DateTime odKiedy, DateTime doKiedy, int idMiejsca, string imie, string nazwisko)
        {
            this.workService.Rezerwacja(odKiedy, doKiedy, idMiejsca, imie, nazwisko);
            return View();
        }

        public IActionResult OdwolajRezerwacje(int idRezerwacji)
        {
            this.workService.OdwolajRezerwacje(idRezerwacji);
            return View();

        }

        public IActionResult EdytujRezerwacje(Rezerwacja rezerwacja)
        {
            this.workService.EdytujRezerwacje(rezerwacja);
            return View();
        }
        public IActionResult PrzedluzRezerwacje(int rezerwacjaId, DateTime doKiedy)
        {
            this.workService.PrzedluzRezerwacje(rezerwacjaId, doKiedy);
            return View();
        }

        public IActionResult ZwrocRezerwacjeWDanymCzasie(DateTime odKiedy, DateTime doKiedy)
        {
            var result = this.workService.ZwrocRezerwacjeWDanymCzasie(odKiedy, doKiedy).Result.ToArray();
            return View(result);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
