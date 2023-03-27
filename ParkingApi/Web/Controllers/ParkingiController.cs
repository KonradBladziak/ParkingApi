using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.DataContext;
using DAL.Entity;

namespace Web.Controllers
{
    public class ParkingiController : Controller
    {
        private readonly DatabaseContext _context;

        public ParkingiController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Parkingi
        public async Task<IActionResult> Index()
        {
            var databaseContext = _context.Parkingi.Include(p => p.Miasto);
            return View(await databaseContext.ToListAsync());
        }

        // GET: Parkingi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Parkingi == null)
            {
                return NotFound();
            }

            var parking = await _context.Parkingi
                .Include(p => p.Miasto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parking == null)
            {
                return NotFound();
            }

            return View(parking);
        }

        // GET: Parkingi/Create
        public IActionResult Create()
        {
            ViewData["IdMiasta"] = new SelectList(_context.Miasta, "Id", "Nazwa");
            return View();
        }

        // POST: Parkingi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nazwa,Adres,IdMiasta")] Parking parking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMiasta"] = new SelectList(_context.Miasta, "Id", "Nazwa", parking.IdMiasta);
            return View(parking);
        }

        // GET: Parkingi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Parkingi == null)
            {
                return NotFound();
            }

            var parking = await _context.Parkingi.FindAsync(id);
            if (parking == null)
            {
                return NotFound();
            }
            ViewData["IdMiasta"] = new SelectList(_context.Miasta, "Id", "Nazwa", parking.IdMiasta);
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
                    _context.Update(parking);
                    await _context.SaveChangesAsync();
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
            ViewData["IdMiasta"] = new SelectList(_context.Miasta, "Id", "Nazwa", parking.IdMiasta);
            return View(parking);
        }

        // GET: Parkingi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Parkingi == null)
            {
                return NotFound();
            }

            var parking = await _context.Parkingi
                .Include(p => p.Miasto)
                .FirstOrDefaultAsync(m => m.Id == id);
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
            if (_context.Parkingi == null)
            {
                return Problem("Entity set 'DatabaseContext.Parkingi'  is null.");
            }
            var parking = await _context.Parkingi.FindAsync(id);
            if (parking != null)
            {
                _context.Parkingi.Remove(parking);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParkingExists(int id)
        {
          return (_context.Parkingi?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
