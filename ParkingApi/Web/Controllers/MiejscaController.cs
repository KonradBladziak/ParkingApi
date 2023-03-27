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
    public class MiejscaController : Controller
    {
        private readonly DatabaseContext _context;

        public MiejscaController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Miejsca
        public async Task<IActionResult> Index()
        {
            var databaseContext = _context.Miejsca.Include(m => m.MiejsceInwalidzkie).Include(m => m.Parking);
            return View(await databaseContext.ToListAsync());
        }

        // GET: Miejsca/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Miejsca == null)
            {
                return NotFound();
            }

            var miejsce = await _context.Miejsca
                .Include(m => m.MiejsceInwalidzkie)
                .Include(m => m.Parking)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (miejsce == null)
            {
                return NotFound();
            }

            return View(miejsce);
        }

        // GET: Miejsca/Create
        public IActionResult Create()
        {
            ViewData["MiejsceInwalidzkieId"] = new SelectList(_context.MiesjcaInwalidzkie, "Id", "Id");
            ViewData["ParkingId"] = new SelectList(_context.Parkingi, "Id", "Adres");
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
                _context.Add(miejsce);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MiejsceInwalidzkieId"] = new SelectList(_context.MiesjcaInwalidzkie, "Id", "Id", miejsce.MiejsceInwalidzkieId);
            ViewData["ParkingId"] = new SelectList(_context.Parkingi, "Id", "Adres", miejsce.ParkingId);
            return View(miejsce);
        }

        // GET: Miejsca/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Miejsca == null)
            {
                return NotFound();
            }

            var miejsce = await _context.Miejsca.FindAsync(id);
            if (miejsce == null)
            {
                return NotFound();
            }
            ViewData["MiejsceInwalidzkieId"] = new SelectList(_context.MiesjcaInwalidzkie, "Id", "Id", miejsce.MiejsceInwalidzkieId);
            ViewData["ParkingId"] = new SelectList(_context.Parkingi, "Id", "Adres", miejsce.ParkingId);
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
                    _context.Update(miejsce);
                    await _context.SaveChangesAsync();
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
            ViewData["MiejsceInwalidzkieId"] = new SelectList(_context.MiesjcaInwalidzkie, "Id", "Id", miejsce.MiejsceInwalidzkieId);
            ViewData["ParkingId"] = new SelectList(_context.Parkingi, "Id", "Adres", miejsce.ParkingId);
            return View(miejsce);
        }

        // GET: Miejsca/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Miejsca == null)
            {
                return NotFound();
            }

            var miejsce = await _context.Miejsca
                .Include(m => m.MiejsceInwalidzkie)
                .Include(m => m.Parking)
                .FirstOrDefaultAsync(m => m.Id == id);
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
            if (_context.Miejsca == null)
            {
                return Problem("Entity set 'DatabaseContext.Miejsca'  is null.");
            }
            var miejsce = await _context.Miejsca.FindAsync(id);
            if (miejsce != null)
            {
                _context.Miejsca.Remove(miejsce);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MiejsceExists(int id)
        {
          return (_context.Miejsca?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
