using DAL.Entity;
using DAL.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class MiejscaController : Controller
    {
        private IUnitOfWork unitOfWork;

        public MiejscaController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WszystkieMiejsca()
        {
            var miasta = unitOfWork.MiejsceRepository.GetAllAsync().Result.ToList();
            ViewBag.Miejsca = miasta;
            return View(miasta);
        }

        public async Task<IActionResult> Create([Bind("ParkingId,MiejsceInwalidzkieId")] Miejsce miejsce)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.MiejsceRepository.Add(miejsce);
                await unitOfWork.SaveAsync();
                return RedirectToAction(nameof(WszystkieMiejsca));
            }
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

                unitOfWork.MiejsceRepository.Update(miejsce);
                await unitOfWork.SaveAsync();
                return RedirectToAction(nameof(WszystkieMiejsca));
            }
            return View(miejsce);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var miejsce = await unitOfWork.MiejsceRepository.GetByIdAsync(id);

            if (miejsce != null)
            {
                unitOfWork.MiejsceRepository.Delete(miejsce);
                await unitOfWork.SaveAsync();
                return RedirectToAction(nameof(WszystkieMiejsca));
            }

            return View(miejsce);
        }
    }
}
