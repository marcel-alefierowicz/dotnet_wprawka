using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using wprawka_01.Models;

namespace wprawka_01.Controllers
{
    public class DenatsController : Controller
    {
        private readonly WprawkaDBContext _context;

        public DenatsController(WprawkaDBContext context)
        {
            _context = context;
        }

        // GET: Denats
        public async Task<IActionResult> Index()
        {
            var wprawkaDBContext = _context.Denaci.Include(d => d.AktualnaPlacowka).Include(d => d.Klient);
            return View(await wprawkaDBContext.ToListAsync());
        }

        // GET: Denats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var denat = await _context.Denaci
                .Include(d => d.AktualnaPlacowka)
                .Include(d => d.Klient)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (denat == null)
            {
                return NotFound();
            }

            return View(denat);
        }

        // GET: Denats/Create
        public IActionResult Create()
        {
            ViewData["PlacowkaId"] = new SelectList(
                _context.Placowki
                    .Select(p => new { p.ID, Display = $"#{p.ID} | {p.KodPocztowy}" })
                    .ToList(),
                "ID",
                "Display");
            ViewData["KlientId"] = new SelectList(_context.Klienci, "ID", "Imie");
            return View();
        }

        // POST: Denats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DataZgonu,KlientId,PlacowkaId,ID,Imie,Nazwisko")] Denat denat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(denat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlacowkaId"] = new SelectList(
                _context.Placowki
                    .Select(p => new { p.ID, Display = $"#{p.ID} | {p.KodPocztowy}" })
                    .ToList(),
                "ID",
                "Display",
                denat.PlacowkaId);
            ViewData["KlientId"] = new SelectList(_context.Klienci, "ID", "Imie", denat.KlientId);
            return View(denat);
        }

        // GET: Denats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var denat = await _context.Denaci.FindAsync(id);
            if (denat == null)
            {
                return NotFound();
            }
            ViewData["PlacowkaId"] = new SelectList(
                _context.Placowki
                    .Select(p => new { p.ID, Display = $"#{p.ID} | {p.KodPocztowy}" })
                    .ToList(),
                "ID",
                "Display",
                denat.PlacowkaId);
            ViewData["KlientId"] = new SelectList(_context.Klienci, "ID", "Imie", denat.KlientId);
            return View(denat);
        }

        // POST: Denats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DataZgonu,KlientId,PlacowkaId,ID,Imie,Nazwisko")] Denat denat)
        {
            if (id != denat.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(denat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DenatExists(denat.ID))
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
            ViewData["PlacowkaId"] = new SelectList(
                _context.Placowki
                    .Select(p => new { p.ID, Display = $"ID: {p.ID} | {p.KodPocztowy}" })
                    .ToList(),
                "ID",
                "Display",
                denat.PlacowkaId);
            ViewData["KlientId"] = new SelectList(_context.Klienci, "ID", "Imie", denat.KlientId);
            return View(denat);
        }

        // GET: Denats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var denat = await _context.Denaci
                .Include(d => d.AktualnaPlacowka)
                .Include(d => d.Klient)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (denat == null)
            {
                return NotFound();
            }

            return View(denat);
        }

        // POST: Denats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var denat = await _context.Denaci.FindAsync(id);
            if (denat != null)
            {
                _context.Denaci.Remove(denat);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DenatExists(int id)
        {
            return _context.Denaci.Any(e => e.ID == id);
        }
    }
}
