using DAL.Entity;
using DAL.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace MVC.Controllers
{
    public class MiastaController : Controller
    {
        private IUnitOfWork unitOfWork;

        public MiastaController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WszystkieMiasta()
        {
            var miasta = unitOfWork.MiastoRepository.GetAllAsync().Result.ToList();
            ViewBag.Miasta = miasta;
            return View(miasta);
        }

        public async Task<IActionResult> Create([Bind("Nazwa,Wojewodztwo")] Miasto miasto)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.MiastoRepository.Add(miasto);
                await unitOfWork.SaveAsync();
                return RedirectToAction(nameof(WszystkieMiasta));
            }
            return View(miasto);
        }

        public async Task<IActionResult> Edit(int id, [Bind("Id,Nazwa,Wojewodztwo")] Miasto miasto)
        {
            if (id != miasto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
               
                unitOfWork.MiastoRepository.Update(miasto);
                await unitOfWork.SaveAsync();
                return RedirectToAction(nameof(WszystkieMiasta));
            }
            return View(miasto);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var miasto = await unitOfWork.MiastoRepository.GetByIdAsync(id);
            
            if (miasto != null)
            {
                unitOfWork.MiastoRepository.Delete(miasto);
                await unitOfWork.SaveAsync();
                return RedirectToAction(nameof(WszystkieMiasta));
            }

            return View(miasto);
        }
    }
}
