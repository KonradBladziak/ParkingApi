using DAL.Entity;
using DAL.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class InwalidzkieController : Controller
    {
        private IUnitOfWork unitOfWork;

        public InwalidzkieController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WszystkieInwalidzkie()
        {
            var inwalidzkie = unitOfWork.MiejsceInwalidzkie.GetAllAsync().Result.ToList();
            ViewBag.Miasta = inwalidzkie;
            return View(inwalidzkie);
        }

        public async Task<IActionResult> Create([Bind("RozmiarMiejsca,IdMiejsca")] MiejsceInwalidzkie inwalidzkie)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.MiejsceInwalidzkie.Add(inwalidzkie);
                await unitOfWork.SaveAsync();
                return RedirectToAction(nameof(WszystkieInwalidzkie));
            }
            return View(inwalidzkie);
        }

        public async Task<IActionResult> Edit(int id, [Bind("Id,RozmiarMiejsca,IdMiejsca")] MiejsceInwalidzkie inwalidzkie)
        {
            if (id != inwalidzkie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                unitOfWork.MiejsceInwalidzkie.Update(inwalidzkie);
                await unitOfWork.SaveAsync();
                return RedirectToAction(nameof(WszystkieInwalidzkie));
            }
            return View(inwalidzkie);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var inwalidzkie = await unitOfWork.MiejsceInwalidzkie.GetByIdAsync(id);

            if (inwalidzkie != null)
            {
                unitOfWork.MiejsceInwalidzkie.Delete(inwalidzkie);
                await unitOfWork.SaveAsync();
                return RedirectToAction(nameof(WszystkieInwalidzkie));
            }

            return View(inwalidzkie);
        }
    }
}
