using BLL.IWorkServices;
using DAL.Entity;
using DAL.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class ParkingiController : Controller
    {
        private IParkingService parkingService;

        public ParkingiController(IParkingService parkingService)
        {
            this.parkingService = parkingService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> WszystkieParkingi()
        {
            var parkingi = await parkingService.GetParkingi();
            return View(parkingi);
        }

        public async Task<IActionResult> Create([Bind("Nazwa,Adres,IdMiasta")] Parking parking)
        {
            if (ModelState.IsValid)
            {
                await parkingService.AddParking(parking);
                return RedirectToAction(nameof(WszystkieParkingi));
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
                return RedirectToAction(nameof(WszystkieParkingi));
            }
            return View(parking);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var parking = await parkingService.GetParkingiById(id);

            if (parking != null)
            {
                await parkingService.DeleteParking(parking);
                return RedirectToAction(nameof(WszystkieParkingi));
            }

            return View(parking);
        }
    }
}
