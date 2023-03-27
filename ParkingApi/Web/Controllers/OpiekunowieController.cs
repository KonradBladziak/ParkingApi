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
    public class OpiekunowieController : Controller
    {
        private readonly DatabaseContext _context;

        public OpiekunowieController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Opiekunowie
        public async Task<IActionResult> Index()
        {
              return _context.Opiekunowie != null ? 
                          View(await _context.Opiekunowie.ToListAsync()) :
                          Problem("Entity set 'DatabaseContext.Opiekunowie'  is null.");
        }

        // GET: Opiekunowie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Opiekunowie == null)
            {
                return NotFound();
            }

            var opiekun = await _context.Opiekunowie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (opiekun == null)
            {
                return NotFound();
            }

            return View(opiekun);
        }

        // GET: Opiekunowie/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Opiekunowie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Imie,Nazwisko")] Opiekun opiekun)
        {
            if (ModelState.IsValid)
            {
                _context.Add(opiekun);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(opiekun);
        }

        // GET: Opiekunowie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Opiekunowie == null)
            {
                return NotFound();
            }

            var opiekun = await _context.Opiekunowie.FindAsync(id);
            if (opiekun == null)
            {
                return NotFound();
            }
            return View(opiekun);
        }

        // POST: Opiekunowie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Imie,Nazwisko")] Opiekun opiekun)
        {
            if (id != opiekun.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(opiekun);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OpiekunExists(opiekun.Id))
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
            return View(opiekun);
        }

        // GET: Opiekunowie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Opiekunowie == null)
            {
                return NotFound();
            }

            var opiekun = await _context.Opiekunowie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (opiekun == null)
            {
                return NotFound();
            }

            return View(opiekun);
        }

        // POST: Opiekunowie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Opiekunowie == null)
            {
                return Problem("Entity set 'DatabaseContext.Opiekunowie'  is null.");
            }
            var opiekun = await _context.Opiekunowie.FindAsync(id);
            if (opiekun != null)
            {
                _context.Opiekunowie.Remove(opiekun);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OpiekunExists(int id)
        {
          return (_context.Opiekunowie?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
