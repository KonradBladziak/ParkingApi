using BLL.IWorkServices;
using BLL.WorkServices;
using DAL.Entity;
using DAL.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class RezerwacjeController : Controller
    {
        private IRezerwacjeService rezerwacjeService;

        public RezerwacjeController(IRezerwacjeService rezerwacjeService)
        {
            this.rezerwacjeService = rezerwacjeService;
        }

        public async Task<IActionResult> Index()
        {
            var rezerwacje = await rezerwacjeService.GetRezerwacje();
            return View(rezerwacje);
        }

        public async Task<IActionResult> Create([Bind("Od,Do,IdMiejsca,Imie,Nazwisko")] Rezerwacja rezerwacja)
        {
            if (ModelState.IsValid)
            {
                await rezerwacjeService.AddRezerwacja(rezerwacja);
                return RedirectToAction(nameof(Index));
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
            return View(rezerwacja);
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
