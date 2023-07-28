using BLL.IWorkServices;
using BLL.WorkServices;
using DAL.Entity;
using DAL.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class OpiekunowieController : Controller
    {
        private IOpiekunService opiekunService;
        private IParkingService parkingService;

        public OpiekunowieController(IOpiekunService opiekunService,IParkingService parkingService)
        {
            this.opiekunService = opiekunService;
            this.parkingService = parkingService;
        }


        public async Task<IActionResult> Index()
        {
            var opiekuni = await opiekunService.GetOpiekunowie();
            return View(opiekuni);
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opiekun = await opiekunService.GetOpiekunByIdDetails(id);

            if (opiekun == null)
            {

                return NotFound();

            }

            return View(opiekun);
        }


        public async Task<IActionResult> Create([Bind("Imie,Nazwisko")] Opiekun opiekun)
        {

            if (ModelState.IsValid)
            {
                await opiekunService.AddOpiekun(opiekun);
                return RedirectToAction(nameof(Index));
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
                return RedirectToAction(nameof(Index));
            }
            return View(opiekun);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var opiekun = await opiekunService.GetOpiekunById(id);

            if (opiekun != null)
            {
                await opiekunService.DeleteOpiekun(opiekun);
                return RedirectToAction(nameof(Index));
            }

            return View(opiekun);
        }
    }
}
