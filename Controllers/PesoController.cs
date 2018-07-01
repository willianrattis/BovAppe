using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SAPP.Data;
using SAPP.Models;

namespace SAPP.Controllers
{
    public class PesoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PesoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Peso
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Pesos.Include(p => p.Animal);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Peso/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peso = await _context.Pesos
                .Include(p => p.Animal)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (peso == null)
            {
                return NotFound();
            }

            return View(peso);
        }

        // GET: Peso/Create
        public IActionResult Create()
        {
            ViewData["AnimalId"] = new SelectList(_context.Animais, "Id", "Tag");
            return View();
        }

        // POST: Peso/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Quilos,Dtpesagem,AnimalId")] Peso peso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(peso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnimalId"] = new SelectList(_context.Animais, "Id", "Tag", peso.AnimalId);
            return View(peso);
        }

        // GET: Peso/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peso = await _context.Pesos.SingleOrDefaultAsync(m => m.Id == id);
            if (peso == null)
            {
                return NotFound();
            }
            ViewData["AnimalId"] = new SelectList(_context.Animais, "Id", "Tag", peso.AnimalId);
            return View(peso);
        }

        // POST: Peso/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Quilos,Dtpesagem,AnimalId")] Peso peso)
        {
            if (id != peso.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(peso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PesoExists(peso.Id))
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
            ViewData["AnimalId"] = new SelectList(_context.Animais, "Id", "Tag", peso.AnimalId);
            return View(peso);
        }

        // GET: Peso/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peso = await _context.Pesos
                .Include(p => p.Animal)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (peso == null)
            {
                return NotFound();
            }

            return View(peso);
        }

        // POST: Peso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var peso = await _context.Pesos.SingleOrDefaultAsync(m => m.Id == id);
            _context.Pesos.Remove(peso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PesoExists(int id)
        {
            return _context.Pesos.Any(e => e.Id == id);
        }
    }
}
