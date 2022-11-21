using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InformeTorneo.Models;

namespace InformeTorneo.Controllers
{
    public class TorneosController : Controller
    {
        private readonly TorneoContext _context;

        public TorneosController(TorneoContext context)
        {
            _context = context;
        }

        // GET: Torneos
        public async Task<IActionResult> Index()
        {
              return View(await _context.Torneos.ToListAsync());
        }

        // GET: Torneos/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Torneos == null)
            {
                return NotFound();
            }

            var torneo = await _context.Torneos
                .FirstOrDefaultAsync(m => m.Nombre == id);
            if (torneo == null)
            {
                return NotFound();
            }

            return View(torneo);
        }

        // GET: Torneos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Torneos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nombre,Anio")] Torneo torneo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(torneo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(torneo);
        }

        // GET: Torneos/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Torneos == null)
            {
                return NotFound();
            }

            var torneo = await _context.Torneos.FindAsync(id);
            if (torneo == null)
            {
                return NotFound();
            }
            return View(torneo);
        }

        // POST: Torneos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Nombre,Anio")] Torneo torneo)
        {
            if (id != torneo.Nombre)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(torneo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TorneoExists(torneo.Nombre))
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
            return View(torneo);
        }

        // GET: Torneos/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Torneos == null)
            {
                return NotFound();
            }

            var torneo = await _context.Torneos
                .FirstOrDefaultAsync(m => m.Nombre == id);
            if (torneo == null)
            {
                return NotFound();
            }

            return View(torneo);
        }

        // POST: Torneos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Torneos == null)
            {
                return Problem("Entity set 'TorneoContext.Torneos'  is null.");
            }
            var torneo = await _context.Torneos.FindAsync(id);
            if (torneo != null)
            {
                _context.Torneos.Remove(torneo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TorneoExists(string id)
        {
          return _context.Torneos.Any(e => e.Nombre == id);
        }
    }
}
