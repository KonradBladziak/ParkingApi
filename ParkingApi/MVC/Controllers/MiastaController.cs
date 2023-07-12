using BLL.IWorkServices;
using DAL.Entity;
using DAL.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace MVC.Controllers
{
    public class MiastaController : Controller
    {
        private IMiastoService miastoService;

        public MiastaController(IMiastoService miastoService)
        {
            this.miastoService = miastoService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> WszystkieMiasta()
        {
            var miasta = await miastoService.GetMiasta();
            return View(miasta);
        }

        public async Task<IActionResult> Create([Bind("Nazwa,Wojewodztwo")] Miasto miasto)
        {
            if (ModelState.IsValid)
            {
                await miastoService.AddMiasto(miasto);
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

                await miastoService.UpdateMiasto(miasto);
                return RedirectToAction(nameof(WszystkieMiasta));
            }
            return View(miasto);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var miasto = await miastoService.GetMiastoById(id);
            
            if (miasto != null)
            {
                await miastoService.DeleteMiasto(miasto);
                return RedirectToAction(nameof(WszystkieMiasta));
            }

            return View(miasto);
        }
    }
}
