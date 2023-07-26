using BLL.IWorkServices;
using BLL.WorkServices;
using DAL.Entity;
using DAL.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Host;

namespace MVC.Controllers
{
    public class ParkingiController : Controller
    {
        private IParkingService parkingService;
        private IMiastoService miastoService;

        public ParkingiController(IParkingService parkingService, IMiastoService miastoService)
        {
            this.parkingService = parkingService;
            this.miastoService = miastoService;
        }


        public async Task<IActionResult> Index()
        {
            var parkingi = await parkingService.GetParkingi();
            return View(parkingi);
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parking = await parkingService.GetParkingiByIdDetails(id);

            if (parking == null)
            {

                return NotFound();

            }

            return View(parking);
        }


        public async Task<IActionResult> Create([Bind("Nazwa,Adres,IdMiasta")] Parking parking)
        {
            if (ModelState.IsValid)
            {

                parking.Miasto = await miastoService.GetMiastoById(parking.IdMiasta);
                await parkingService.AddParking(parking);
                return RedirectToAction(nameof(Index));
            }
            return View(parking);
        }

        public async Task<IActionResult> Edit(int id, [Bind("Id,Nazwa,Adres,IdMiasta")] Parking parking)
        {
            if (id != parking.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                await parkingService.UpdateParking(parking);
                return RedirectToAction(nameof(Index));
            }
           
            return View(await parkingService.GetParkingiByIdDetails(id));
        }
        public async Task<IActionResult> Delete(int id)
        {
            var parking = await parkingService.GetParkingiById(id);

            if (parking != null)
            {
                await parkingService.DeleteParking(parking);
                return RedirectToAction(nameof(Index));
            }

            return View(parking);
        }
    }
}
