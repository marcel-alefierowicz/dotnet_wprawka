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
    public class PlacowkaController : Controller
    {
        private readonly WprawkaDBContext _context;

        public PlacowkaController(WprawkaDBContext context)
        {
            _context = context;
        }

        // GET: Placowka
        public async Task<IActionResult> Index()
        {
            return View(await _context.Placowki.ToListAsync());
        }

        // GET: Placowka/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var placowka = await _context.Placowki
                .FirstOrDefaultAsync(m => m.ID == id);
            if (placowka == null)
            {
                return NotFound();
            }

            return View(placowka);
        }

        // GET: Placowka/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Placowka/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Ulica,Miasto,KodPocztowy,NumerTelefonu")] Placowka placowka)
        {
            if (ModelState.IsValid)
            {
                _context.Add(placowka);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(placowka);
        }

        // GET: Placowka/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var placowka = await _context.Placowki.FindAsync(id);
            if (placowka == null)
            {
                return NotFound();
            }
            return View(placowka);
        }

        // POST: Placowka/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Ulica,Miasto,KodPocztowy,NumerTelefonu")] Placowka placowka)
        {
            if (id != placowka.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(placowka);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlacowkaExists(placowka.ID))
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
            return View(placowka);
        }

        // GET: Placowka/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var placowka = await _context.Placowki
                .FirstOrDefaultAsync(m => m.ID == id);
            if (placowka == null)
            {
                return NotFound();
            }

            return View(placowka);
        }

        // POST: Placowka/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var placowka = await _context.Placowki.FindAsync(id);
            if (placowka != null)
            {
                _context.Placowki.Remove(placowka);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlacowkaExists(int id)
        {
            return _context.Placowki.Any(e => e.ID == id);
        }
    }
}
