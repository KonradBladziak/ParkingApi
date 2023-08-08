using BLL.IWorkServices;
using BLL.WorkServices;
using DAL.Entity;
using DAL.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System.Data.Odbc;

namespace MVC.Controllers
{
    public class RezerwacjeController : Controller
    {
        private IRezerwacjeService rezerwacjeService;
        private IMiejsceService miejscaService;

        public RezerwacjeController(IRezerwacjeService rezerwacjeService,IMiejsceService miejscaService)
        {
            this.rezerwacjeService = rezerwacjeService;
            this.miejscaService = miejscaService;
        }

        public async Task<IActionResult> Index()
        {
            var rezerwacje = await rezerwacjeService.GetRezerwacje();
            return View(rezerwacje);
        }

        public async Task<IActionResult> Create([Bind("Od,Do,IdMiejsca,Imie,Nazwisko")] Rezerwacja rezerwacja)
        {
            ViewBag.Message = null;

            if (rezerwacja.IdMiejsca != null && rezerwacja.Od >= DateTime.Now && rezerwacja.Do > rezerwacja.Od)
            {
                if (await rezerwacjeService.CzyMoznaRezerwowac(rezerwacja.IdMiejsca, rezerwacja.Od, rezerwacja.Do))
                {
                    await rezerwacjeService.AddRezerwacja(rezerwacja);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Message = "Ta data koliduje z inną rezerwacją dla tego miejsca";
                }
            }
            

            return View(rezerwacja);
        }

        public async Task<IActionResult> Edit(int id, [Bind("Id,Od,Do,IdMiejsca,Imie,Nazwisko")] Rezerwacja rezerwacja)
        {
            if (id != rezerwacja.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                await rezerwacjeService.UpdateRezerwacja(rezerwacja);
                return RedirectToAction(nameof(Index));
            }
            return View(await rezerwacjeService.GetRezerwacjaByIdDetails(id));
        }
        public async Task<IActionResult> Delete(int id)
        {
            var rezerwacja = await rezerwacjeService.GetRezerwacjaById(id);

            if (rezerwacja != null)
            {
                await rezerwacjeService.DeleteRezerwacja(rezerwacja);
                return RedirectToAction(nameof(Index));
            }

            return View(rezerwacja);
        }
    }
}
