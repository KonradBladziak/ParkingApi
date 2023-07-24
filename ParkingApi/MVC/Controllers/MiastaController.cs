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
        public async Task<IActionResult> Index()
        {
            var miasta = await miastoService.GetMiasta();
            return View(miasta);
        }

        public async Task<IActionResult> Details(int id) 
        {
            if (id == null)
            {
                return NotFound();
            }

            var miasto = await miastoService.GetMiastoByIdDetails(id);

            if (miasto == null) {
                
                return NotFound();
            
            }

            return View(miasto);
        }

        public async Task<IActionResult> Create([Bind("Nazwa,Wojewodztwo")] Miasto miasto)
        {
            if (ModelState.IsValid)
            {
                await miastoService.AddMiasto(miasto);
                return RedirectToAction(nameof(Index));
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
                return RedirectToAction(nameof(Index));
            }
            
            return View(await miastoService.GetMiastoById(id));
        }
        public async Task<IActionResult> Delete(int id)
        {
            var miasto = await miastoService.GetMiastoById(id);
            
            if (miasto != null)
            {
                await miastoService.DeleteMiasto(miasto);
                return RedirectToAction(nameof(Index));
            }

            return View(miasto);
        }
    }
}
