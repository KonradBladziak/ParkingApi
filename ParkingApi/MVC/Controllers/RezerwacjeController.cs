using DAL.Entity;
using DAL.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class RezerwacjeController : Controller
    {
        private IUnitOfWork unitOfWork;

        public RezerwacjeController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WszystkieRezerwacje()
        {
            var rezerwacje = unitOfWork.RezerwacjaRepository.GetAllAsync().Result.ToList();
            ViewBag.Miasta = rezerwacje;
            return View(rezerwacje);
        }

        public async Task<IActionResult> Create([Bind("Od,Do,IdMiejsca,Imie,Nazwisko")] Rezerwacja rezerwacja)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.RezerwacjaRepository.Add(rezerwacja);
                await unitOfWork.SaveAsync();
                return RedirectToAction(nameof(WszystkieRezerwacje));
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

                unitOfWork.RezerwacjaRepository.Update(rezerwacja);
                await unitOfWork.SaveAsync();
                return RedirectToAction(nameof(WszystkieRezerwacje));
            }
            return View(rezerwacja);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var rezerwacja = await unitOfWork.RezerwacjaRepository.GetByIdAsync(id);

            if (rezerwacja != null)
            {
                unitOfWork.RezerwacjaRepository.Delete(rezerwacja);
                await unitOfWork.SaveAsync();
                return RedirectToAction(nameof(WszystkieRezerwacje));
            }

            return View(rezerwacja);
        }
    }
}
