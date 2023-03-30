using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.DataContext;
using DAL.Entity;
using DAL.UnitOfWork;
using DAL.Repositories;

namespace Web.Controllers
{
    public class MiejscaInwalidzkieController : Controller
    {
        private IUnitOfWork unitOfWork;

        public MiejscaInwalidzkieController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: MiejscaInwalidzkie
        public async Task<IActionResult> Index()
        {
            return unitOfWork.InwalidzkieRepository.GetMiejscaInwalidzkie != null ?
                           View(await unitOfWork.InwalidzkieRepository.GetMiejscaInwalidzkie()) :
                           Problem("Entity set 'DatabaseContext.Miejsca'  is null.");
        }

        // GET: MiejscaInwalidzkie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var miejsceInwalidzkie = await unitOfWork.InwalidzkieRepository.GetMiejsceInwalidzkieById(id);

            if (miejsceInwalidzkie == null)
            {
                return NotFound();
            }

            return View(miejsceInwalidzkie);
        }

        // GET: MiejscaInwalidzkie/Create
        public IActionResult Create()
        {
            ViewData["IdMiejsca"] = new SelectList(unitOfWork.MiejsceRepository.GetMiejsca().Result, "Id", "Id");
            return View();
        }

        // POST: MiejscaInwalidzkie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RozmiarMiejsca,IdMiejsca")] MiejsceInwalidzkie miejsceInwalidzkie)
        {
            if (ModelState.IsValid)
            {
                await unitOfWork.InwalidzkieRepository.InsertMiejsceInwalidzkie(miejsceInwalidzkie);
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMiejsca"] = new SelectList(unitOfWork.MiejsceRepository.GetMiejsca().Result, "Id", "Id", miejsceInwalidzkie.IdMiejsca);
            return View(miejsceInwalidzkie);
        }

        // GET: MiejscaInwalidzkie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || unitOfWork.InwalidzkieRepository.GetMiejscaInwalidzkie().Result == null)
            {
                return NotFound();
            }

            var miejsceInwalidzkie = await unitOfWork.InwalidzkieRepository.GetMiejsceInwalidzkieById(id);
            if (miejsceInwalidzkie == null)
            {
                return NotFound();
            }
            ViewData["IdMiejsca"] = new SelectList(unitOfWork.MiejsceRepository.GetMiejsca().Result, "Id", "Id", miejsceInwalidzkie.IdMiejsca);
            return View(miejsceInwalidzkie);
        }

        // POST: MiejscaInwalidzkie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RozmiarMiejsca,IdMiejsca")] MiejsceInwalidzkie miejsceInwalidzkie)
        {
            if (id != miejsceInwalidzkie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await unitOfWork.InwalidzkieRepository.UpdateMiejsceInwalidzkie(miejsceInwalidzkie);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MiejsceInwalidzkieExists(miejsceInwalidzkie.Id))
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
            ViewData["IdMiejsca"] = new SelectList(unitOfWork.MiejsceRepository.GetMiejsca().Result, "Id", "Id", miejsceInwalidzkie.IdMiejsca);
            return View(miejsceInwalidzkie);
        }

        // GET: MiejscaInwalidzkie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || unitOfWork.InwalidzkieRepository.GetMiejscaInwalidzkie == null)
            {
                return NotFound();
            }

            var miejsceInwalidzkie = unitOfWork.InwalidzkieRepository.GetMiejsceInwalidzkieById(id);
            if (miejsceInwalidzkie == null)
            {
                return NotFound();
            }

            return View(miejsceInwalidzkie);
        }

        // POST: MiejscaInwalidzkie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (unitOfWork.InwalidzkieRepository.GetMiejscaInwalidzkie == null)
            {
                return Problem("Entity set 'DatabaseContext.MiesjcaInwalidzkie'  is null.");
            }
            var miejsceInwalidzkie = await unitOfWork.InwalidzkieRepository.GetMiejsceInwalidzkieById(id);
            if (miejsceInwalidzkie != null)
            {
                await unitOfWork.InwalidzkieRepository.DeleteMiejsceInwalidzkie(miejsceInwalidzkie);
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool MiejsceInwalidzkieExists(int id)
        {
          return unitOfWork.InwalidzkieRepository.GetMiejsceInwalidzkieById(id) != null ? true : false;
        }
    }
}
