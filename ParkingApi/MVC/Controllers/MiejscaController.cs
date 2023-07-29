using BLL.IWorkServices;
using BLL.WorkServices;
using DAL.Entity;
using DAL.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC.Controllers
{
    public class MiejscaController : Controller
    {
        private IMiejsceService miejscaService;
        private IParkingService parkingService;

        public MiejscaController(IMiejsceService miejscaService, IParkingService parkingService)
        {
            this.miejscaService = miejscaService;
            this.parkingService = parkingService;
        }
        public async Task<IActionResult> Index()
        {
            var miejsca = await miejscaService.GetMiejsca();
            return View(miejsca);
        }

        public async Task<IActionResult> Details(int id) 
        {
            if (id == null)
            {
                return NotFound();
            }

            var miejsce = await miejscaService.GetMiejsceByIdDetails(id);

            if (miejsce == null)
            {

                return NotFound();

            }

            return View(miejsce);
        }

        public async Task<IActionResult> Create([Bind("ParkingId")] Miejsce miejsce)
        {
            if (ModelState.IsValid)
            {
                await miejscaService.AddMiejsce(miejsce);
                return RedirectToAction(nameof(Index));
            }

            Parking parking = new Parking();

            ViewData["IdParkingu"] = new SelectList(await parkingService.GetParkingi(), "Id", "Nazwa",miejsce.ParkingId);

            return View(miejsce);
        }

        public async Task<IActionResult> Edit(int id, [Bind("Id,ParkingId,MiejsceInwalidzkieId")] Miejsce miejsce)
        {
            if (id != miejsce.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                miejscaService.UpdateMiejsce(miejsce);
                return RedirectToAction(nameof(Index));
            }
            return View(miejsce);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var miejsce = await miejscaService.GetMiejsceById(id);

            if (miejsce != null)
            {
                await miejscaService.DeleteMiejsce(miejsce);
                return RedirectToAction(nameof(Index));
            }

            return View(miejsce);
        }
    }
}
