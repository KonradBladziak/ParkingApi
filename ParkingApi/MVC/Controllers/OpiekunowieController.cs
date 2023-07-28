using BLL.IWorkServices;
using DAL.Entity;
using DAL.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class OpiekunowieController : Controller
    {
        private IOpiekunService opiekunService;

        public OpiekunowieController(IOpiekunService opiekunService)
        {
            this.opiekunService = opiekunService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> WszyscyOpiekunowie()
        {
            var opiekunowie = await opiekunService.GetOpiekunowie();
            return View(opiekunowie);
        }

        public async Task<IActionResult> Create([Bind("Imie,Nazwisko")] Opiekun opiekun)
        {
            if (ModelState.IsValid)
            {
                await opiekunService.AddOpiekun(opiekun);
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

                await opiekunService.UpdateOpiekun(opiekun);
                return RedirectToAction(nameof(WszyscyOpiekunowie));
            }
            return View(opiekun);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var opiekun = await opiekunService.GetOpiekunById(id);

            if (opiekun != null)
            {
                await opiekunService.AddOpiekun(opiekun);
                return RedirectToAction(nameof(WszyscyOpiekunowie));
            }

            return View(opiekun);
        }
    }
}
