using DAL.Entity;
using DAL.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class OpiekunowieController : Controller
    {
        private IUnitOfWork unitOfWork;

        public OpiekunowieController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WszyscyOpiekunowie()
        {
            var opiekunowie = unitOfWork.OpiekunRepository.GetAllAsync().Result.ToList();
            ViewBag.Miasta = opiekunowie;
            return View(opiekunowie);
        }

        public async Task<IActionResult> Create([Bind("Imie,Nazwisko")] Opiekun opiekun)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.OpiekunRepository.Add(opiekun);
                await unitOfWork.SaveAsync();
                return RedirectToAction(nameof(WszyscyOpiekunowie));
            }
            return View(opiekun);
        }

        public async Task<IActionResult> Edit(int id, [Bind("Id,Imie,Nazwisko")] Opiekun opiekun)
        {
            if (id != opiekun.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                unitOfWork.OpiekunRepository.Update(opiekun);
                await unitOfWork.SaveAsync();
                return RedirectToAction(nameof(WszyscyOpiekunowie));
            }
            return View(opiekun);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var opiekun = await unitOfWork.OpiekunRepository.GetByIdAsync(id);

            if (opiekun != null)
            {
                unitOfWork.OpiekunRepository.Delete(opiekun);
                await unitOfWork.SaveAsync();
                return RedirectToAction(nameof(WszyscyOpiekunowie));
            }

            return View(opiekun);
        }
    }
}
