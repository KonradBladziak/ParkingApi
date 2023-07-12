using DAL.Entity;
using DAL.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class ParkingiController : Controller
    {
        private IUnitOfWork unitOfWork;

        public ParkingiController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WszystkieParkingi()
        {
            var parkingi = unitOfWork.ParkingRepository.GetAllAsync().Result.ToList();
            ViewBag.Miasta = parkingi;
            return View(parkingi);
        }

        public async Task<IActionResult> Create([Bind("Nazwa,Adres,IdMiasta")] Parking parking)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.ParkingRepository.Add(parking);
                await unitOfWork.SaveAsync();
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

                unitOfWork.ParkingRepository.Update(parking);
                await unitOfWork.SaveAsync();
                return RedirectToAction(nameof(WszystkieParkingi));
            }
            return View(parking);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var parking = await unitOfWork.ParkingRepository.GetByIdAsync(id);

            if (parking != null)
            {
                unitOfWork.ParkingRepository.Delete(parking);
                await unitOfWork.SaveAsync();
                return RedirectToAction(nameof(WszystkieParkingi));
            }

            return View(parking);
        }
    }
}
