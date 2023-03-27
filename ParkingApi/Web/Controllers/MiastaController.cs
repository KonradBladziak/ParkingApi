using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.DataContext;
using DAL.Entity;
using DAL.IRepositories;
using DAL.Repositories;
using DAL.UnitOfWork;

namespace Web.Controllers
{
    public class MiastaController : Controller
    {
        private IUnitOfWork unitOfWork;

        public MiastaController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: Miasta
        public async Task<IActionResult> Index()
        {
              return unitOfWork.MiastoRepository.GetMiasta != null ? 
                          View(await unitOfWork.MiastoRepository.GetMiasta()) :
                          Problem("Entity set 'DatabaseContext.Miasta'  is null.");
        }

        // GET: Miasta/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || unitOfWork.MiastoRepository.GetMiasta == null)
            {
                return NotFound();
            }

            var miasto = await unitOfWork.MiastoRepository.GetMiastoById(id);

            if (miasto == null)
            {
                return NotFound();
            }

            return View(miasto);
        }

        // GET: Miasta/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Miasta/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nazwa,Wojewodztwo")] Miasto miasto)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.MiastoRepository.InsertMiasto(miasto);
                await unitOfWork.MiastoRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(miasto);
        }

        // GET: Miasta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || unitOfWork.MiastoRepository.GetMiasta == null)
            {
                return NotFound();
            }

            var miasto = await unitOfWork.MiastoRepository.GetMiastoById(id);
            if (miasto == null)
            {
                return NotFound();
            }
            return View(miasto);
        }

        // POST: Miasta/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nazwa,Wojewodztwo")] Miasto miasto)
        {
            if (id != miasto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    unitOfWork.MiastoRepository.UpdateMiasto(miasto);
                    await unitOfWork.MiastoRepository.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MiastoExists(miasto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(miasto);
        }

        // GET: Miasta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || unitOfWork.MiastoRepository.GetMiasta == null)
            {
                return NotFound();
            }

            var miasto = await unitOfWork.MiastoRepository.GetMiastoById(id);
            if (miasto == null)
            {
                return NotFound();
            }

            return View(miasto);
        }

        // POST: Miasta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (unitOfWork.MiastoRepository.GetMiasta == null)
            {
                return Problem("Entity set 'DatabaseContext.Miasta'  is null.");
            }
            var miasto = unitOfWork.MiastoRepository.GetMiastoById(id);
            if (miasto != null)
            {
                unitOfWork.MiastoRepository.DeleteMiasto(id);
            }
            
            await unitOfWork.MiastoRepository.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool MiastoExists(int id)
        {
            var res = false;

            if (unitOfWork.MiastoRepository.GetMiastoById(id) != null)
            {
                res = true;
            }

            return res;
        }

    }
}
