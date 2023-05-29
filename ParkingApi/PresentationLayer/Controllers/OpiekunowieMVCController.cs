using BLL;
using DAL.Entity;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class OpiekunowieMVCController : Controller
    {
        private readonly IWorkService workService;

        public OpiekunowieMVCController(IWorkService workService)
        {
            this.workService = workService;
        }

        public IActionResult StworzOpiekuna(string imie, string nazwisko)
        {
            this.workService.StworzOpiekuna(new Opiekun { Imie = imie, Nazwisko = nazwisko });
            return View();
        }

        public IActionResult UsunOpiekuna(int idOpiekuna)
        {
            this.workService.UsunOpiekuna(idOpiekuna);
            return View();
        }

        public IActionResult ZwrocParkingiDanegoOpiekuna(int idOpiekuna)
        {
            var res = this.workService.ZwrocParkingiDanegoOpiekuna(idOpiekuna).Result.Count();
            return View(res);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
