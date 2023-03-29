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
    public class ParkingiController : Controller
    {
        private readonly DatabaseContext _context;

        private IUnitOfWork unitOfWork;

        public ParkingiController(DatabaseContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            this.unitOfWork = unitOfWork;
        }

        // GET: Parkingi
        public async Task<IActionResult> Index()
        {
            return unitOfWork.ParkingRepository.GetParkingi != null ?
                          View(await unitOfWork.ParkingRepository.GetParkingi()) :
                          Problem("Entity set 'DatabaseContext.Parkingi'  is null.");
        }

        // GET: Parkingi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parking = await unitOfWork.ParkingRepository.GetParkingById(id);
            
            if (parking == null)
            {
                return NotFound();
            }

            return View(parking);
        }

        // GET: Parkingi/Create
        public IActionResult Create()
        {
            ViewData["IdMiasta"] = new SelectList(unitOfWork.MiastoRepository.GetMiasta().Result, "Id", "Nazwa");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nazwa,Adres,IdMiasta")] Parking parking)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.ParkingRepository.InsertParking(parking);
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMiasta"] = new SelectList(unitOfWork.MiastoRepository.GetMiasta().Result, "Id", "Nazwa", parking.IdMiasta);
            return View(parking);
        }

        // GET: Parkingi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || unitOfWork.MiastoRepository.GetMiasta().Result == null)
            {
                return NotFound();
            }

            var parking = await unitOfWork.ParkingRepository.GetParkingById(id);
            if (parking == null)
            {
                return NotFound();
            }
            ViewData["IdMiasta"] = new SelectList(unitOfWork.MiastoRepository.GetMiasta().Result, "Id", "Nazwa", parking.IdMiasta);
            return View(parking);
        }

        // POST: Parkingi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nazwa,Adres,IdMiasta")] Parking parking)
        {
            if (id != parking.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    unitOfWork.ParkingRepository.UpdateParking(parking);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParkingExists(parking.Id))
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
            ViewData["IdMiasta"] = new SelectList(unitOfWork.MiastoRepository.GetMiasta().Result, "Id", "Nazwa", parking.IdMiasta);
            return View(parking);
        }

        // GET: Parkingi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || unitOfWork.ParkingRepository.GetParkingi == null)
            {
                return NotFound();
            }

            var parking = await unitOfWork.ParkingRepository.GetParkingById(id);
            if (parking == null)
            {
                return NotFound();
            }

            return View(parking);
        }

        // POST: Parkingi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (unitOfWork.ParkingRepository.GetParkingi == null)
            {
                return Problem("Entity set 'DatabaseContext.Parkingi'  is null.");
            }
            var parking = await unitOfWork.ParkingRepository.GetParkingById(id);
            if (parking != null)
            {
                unitOfWork.ParkingRepository.DeleteParking(parking);
            }
            
            
            return RedirectToAction(nameof(Index));
        }

        private bool ParkingExists(int id)
        { 
          return unitOfWork.ParkingRepository.GetParkingById(id) != null ? true : false;
        }
    }
}
