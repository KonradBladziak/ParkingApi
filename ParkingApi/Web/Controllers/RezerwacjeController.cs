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
    public class RezerwacjeController : Controller
    {
        private readonly DatabaseContext _context;

        public RezerwacjeController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Rezerwacje
        public async Task<IActionResult> Index()
        {
            var databaseContext = _context.Rezerwacje.Include(r => r.Miejsce);
            return View(await databaseContext.ToListAsync());
        }

        // GET: Rezerwacje/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Rezerwacje == null)
            {
                return NotFound();
            }

            var rezerwacja = await _context.Rezerwacje
                .Include(r => r.Miejsce)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rezerwacja == null)
            {
                return NotFound();
            }

            return View(rezerwacja);
        }

        // GET: Rezerwacje/Create
        public IActionResult Create()
        {
            ViewData["IdMiejsca"] = new SelectList(_context.Miejsca, "Id", "Id");
            return View();
        }

        // POST: Rezerwacje/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Od,Do,IdMiejsca,Imie,Nazwisko")] Rezerwacja rezerwacja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rezerwacja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMiejsca"] = new SelectList(_context.Miejsca, "Id", "Id", rezerwacja.IdMiejsca);
            return View(rezerwacja);
        }

        // GET: Rezerwacje/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Rezerwacje == null)
            {
                return NotFound();
            }

            var rezerwacja = await _context.Rezerwacje.FindAsync(id);
            if (rezerwacja == null)
            {
                return NotFound();
            }
            ViewData["IdMiejsca"] = new SelectList(_context.Miejsca, "Id", "Id", rezerwacja.IdMiejsca);
            return View(rezerwacja);
        }

        // POST: Rezerwacje/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Od,Do,IdMiejsca,Imie,Nazwisko")] Rezerwacja rezerwacja)
        {
            if (id != rezerwacja.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rezerwacja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RezerwacjaExists(rezerwacja.Id))
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
            ViewData["IdMiejsca"] = new SelectList(_context.Miejsca, "Id", "Id", rezerwacja.IdMiejsca);
            return View(rezerwacja);
        }

        // GET: Rezerwacje/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Rezerwacje == null)
            {
                return NotFound();
            }

            var rezerwacja = await _context.Rezerwacje
                .Include(r => r.Miejsce)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rezerwacja == null)
            {
                return NotFound();
            }

            return View(rezerwacja);
        }

        // POST: Rezerwacje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Rezerwacje == null)
            {
                return Problem("Entity set 'DatabaseContext.Rezerwacje'  is null.");
            }
            var rezerwacja = await _context.Rezerwacje.FindAsync(id);
            if (rezerwacja != null)
            {
                _context.Rezerwacje.Remove(rezerwacja);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RezerwacjaExists(int id)
        {
          return (_context.Rezerwacje?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
