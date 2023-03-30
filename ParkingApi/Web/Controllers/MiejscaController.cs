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

namespace Web.Controllers
{
    public class MiejscaController : Controller
    {
        private IUnitOfWork unitOfWork;
        public MiejscaController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: Miejsca
        public async Task<IActionResult> Index()
        {
            return unitOfWork.MiejsceRepository.GetMiejsca != null ?
                           View(await unitOfWork.MiejsceRepository.GetMiejsca()) :
                           Problem("Entity set 'DatabaseContext.Miejsca'  is null.");
        }

        // GET: Miejsca/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var miejsce = await unitOfWork.MiejsceRepository.GetMiejscaById(id);

            if (miejsce == null)
            {
                return NotFound();
            }

            return View(miejsce);
        }

        // GET: Miejsca/Create
        public IActionResult Create()
        {
            ViewData["MiejsceInwalidzkieId"] = new SelectList(unitOfWork.InwalidzkieRepository.GetMiejscaInwalidzkie().Result, "Id", "Id");
            ViewData["ParkingId"] = new SelectList(unitOfWork.ParkingRepository.GetParkingi().Result, "Id", "Adres");
            return View();
        }

        // POST: Miejsca/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ParkingId,MiejsceInwalidzkieId")] Miejsce miejsce)
        {
            if (ModelState.IsValid)
            {
                await unitOfWork.MiejsceRepository.InsertMiejsce(miejsce);
                return RedirectToAction(nameof(Index));
            }
            ViewData["MiejsceInwalidzkieId"] = new SelectList(unitOfWork.InwalidzkieRepository.GetMiejscaInwalidzkie().Result, "Id", "Id", miejsce.MiejsceInwalidzkieId);
            ViewData["ParkingId"] = new SelectList(unitOfWork.ParkingRepository.GetParkingi().Result, "Id", "Adres", miejsce.ParkingId);
            return View(miejsce);
        }

        // GET: Miejsca/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || unitOfWork.MiejsceRepository.GetMiejsca().Result == null)
            {
                return NotFound();
            }

            var miejsce = await unitOfWork.MiejsceRepository.GetMiejscaById(id);
            if (miejsce == null)
            {
                return NotFound();
            }

            ViewData["MiejsceInwalidzkieId"] = new SelectList(unitOfWork.InwalidzkieRepository.GetMiejscaInwalidzkie().Result, "Id", "Id", miejsce.MiejsceInwalidzkieId);
            ViewData["ParkingId"] = new SelectList(unitOfWork.ParkingRepository.GetParkingi().Result, "Id", "Adres", miejsce.ParkingId);
            return View(miejsce);
        }

        // POST: Miejsca/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ParkingId,MiejsceInwalidzkieId")] Miejsce miejsce)
        {
            if (id != miejsce.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   await unitOfWork.MiejsceRepository.UpdateMiejsce(miejsce);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MiejsceExists(miejsce.Id))
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
            ViewData["MiejsceInwalidzkieId"] = new SelectList(unitOfWork.InwalidzkieRepository.GetMiejscaInwalidzkie().Result, "Id", "Id", miejsce.MiejsceInwalidzkieId);
            ViewData["ParkingId"] = new SelectList(unitOfWork.ParkingRepository.GetParkingi().Result, "Id", "Adres", miejsce.ParkingId);
            return View(miejsce);
        }

        // GET: Miejsca/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || unitOfWork.MiejsceRepository.GetMiejsca == null)
            {
                return NotFound();
            }

            var miejsce = unitOfWork.MiejsceRepository.GetMiejscaById(id);
            if (miejsce == null)
            {
                return NotFound();
            }

            return View(miejsce);
        }

        // POST: Miejsca/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (unitOfWork.MiejsceRepository.GetMiejsca == null)
            {
                return Problem("Entity set 'DatabaseContext.Miejsca'  is null.");
            }
            var miejsce = await unitOfWork.MiejsceRepository.GetMiejscaById(id);
            if (miejsce != null)
            {
                await unitOfWork.MiejsceRepository.DeleteMiejsce(miejsce);
            }
        
            return RedirectToAction(nameof(Index));
        }

        private bool MiejsceExists(int id)
        {
          return unitOfWork.MiejsceRepository.GetMiejscaById(id) != null ? true : false;
        }
    }
}
