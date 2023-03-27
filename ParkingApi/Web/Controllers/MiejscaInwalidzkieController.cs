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
    public class MiejscaInwalidzkieController : Controller
    {
        private readonly DatabaseContext _context;

        public MiejscaInwalidzkieController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: MiejscaInwalidzkie
        public async Task<IActionResult> Index()
        {
            var databaseContext = _context.MiesjcaInwalidzkie.Include(m => m.Miejsce);
            return View(await databaseContext.ToListAsync());
        }

        // GET: MiejscaInwalidzkie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MiesjcaInwalidzkie == null)
            {
                return NotFound();
            }

            var miejsceInwalidzkie = await _context.MiesjcaInwalidzkie
                .Include(m => m.Miejsce)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (miejsceInwalidzkie == null)
            {
                return NotFound();
            }

            return View(miejsceInwalidzkie);
        }

        // GET: MiejscaInwalidzkie/Create
        public IActionResult Create()
        {
            ViewData["IdMiejsca"] = new SelectList(_context.Miejsca, "Id", "Id");
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
                _context.Add(miejsceInwalidzkie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMiejsca"] = new SelectList(_context.Miejsca, "Id", "Id", miejsceInwalidzkie.IdMiejsca);
            return View(miejsceInwalidzkie);
        }

        // GET: MiejscaInwalidzkie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MiesjcaInwalidzkie == null)
            {
                return NotFound();
            }

            var miejsceInwalidzkie = await _context.MiesjcaInwalidzkie.FindAsync(id);
            if (miejsceInwalidzkie == null)
            {
                return NotFound();
            }
            ViewData["IdMiejsca"] = new SelectList(_context.Miejsca, "Id", "Id", miejsceInwalidzkie.IdMiejsca);
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
                    _context.Update(miejsceInwalidzkie);
                    await _context.SaveChangesAsync();
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
            ViewData["IdMiejsca"] = new SelectList(_context.Miejsca, "Id", "Id", miejsceInwalidzkie.IdMiejsca);
            return View(miejsceInwalidzkie);
        }

        // GET: MiejscaInwalidzkie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MiesjcaInwalidzkie == null)
            {
                return NotFound();
            }

            var miejsceInwalidzkie = await _context.MiesjcaInwalidzkie
                .Include(m => m.Miejsce)
                .FirstOrDefaultAsync(m => m.Id == id);
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
            if (_context.MiesjcaInwalidzkie == null)
            {
                return Problem("Entity set 'DatabaseContext.MiesjcaInwalidzkie'  is null.");
            }
            var miejsceInwalidzkie = await _context.MiesjcaInwalidzkie.FindAsync(id);
            if (miejsceInwalidzkie != null)
            {
                _context.MiesjcaInwalidzkie.Remove(miejsceInwalidzkie);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MiejsceInwalidzkieExists(int id)
        {
          return (_context.MiesjcaInwalidzkie?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
