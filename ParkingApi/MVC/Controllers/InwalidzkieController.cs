using BLL.IWorkServices;
using DAL.Entity;
using DAL.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class InwalidzkieController : Controller
    {
        private IMiejscaInwalidzkieService miejscaInwalidzkieService;

        public InwalidzkieController(IMiejscaInwalidzkieService miejscaInwalidzkieService)
        {
            this.miejscaInwalidzkieService = miejscaInwalidzkieService;
        }
        public async Task<IActionResult> Index()
        {
            var miejsca = await miejscaInwalidzkieService.GetMiejscaInwalidzkie();
            return View(miejsca);
        }
        public async Task<IActionResult> Create([Bind("RozmiarMiejsca,IdMiejsca")] MiejsceInwalidzkie inwalidzkie)
        {
            if (ModelState.IsValid)
            {
                miejscaInwalidzkieService.AddMiejsceInwalidzkie(inwalidzkie);
                return RedirectToAction(nameof(Index));
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
                await miejscaInwalidzkieService.UpdateMiejsceInwalidzkie(inwalidzkie);
                return RedirectToAction(nameof(Index));
            }
            return View(inwalidzkie);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var inwalidzkie = await miejscaInwalidzkieService.GetMiejsceInwalidzkieById(id);

            if (inwalidzkie != null)
            {
                miejscaInwalidzkieService.DeleteMiejsceInwalidzkie(inwalidzkie);
                return RedirectToAction(nameof(Index));
            }

            return View(inwalidzkie);
        }
    }
}
