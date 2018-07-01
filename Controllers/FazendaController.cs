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
    public class FazendaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FazendaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Fazenda
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Fazendas.Include(f => f.Cliente);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Fazenda/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fazenda = await _context.Fazendas
                .Include(f => f.Cliente)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (fazenda == null)
            {
                return NotFound();
            }

            return View(fazenda);
        }

        // GET: Fazenda/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nome");//,"CPF"
            return View();
        }

        // POST: Fazenda/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,ClienteId")] Fazenda fazenda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fazenda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nome", fazenda.ClienteId);
            return View(fazenda);
        }

        // GET: Fazenda/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fazenda = await _context.Fazendas.SingleOrDefaultAsync(m => m.Id == id);
            if (fazenda == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "CPF", fazenda.ClienteId);
            return View(fazenda);
        }

        // POST: Fazenda/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,ClienteId")] Fazenda fazenda)
        {
            if (id != fazenda.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fazenda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FazendaExists(fazenda.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "CPF", fazenda.ClienteId);
            return View(fazenda);
        }

        // GET: Fazenda/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fazenda = await _context.Fazendas
                .Include(f => f.Cliente)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (fazenda == null)
            {
                return NotFound();
            }

            return View(fazenda);
        }

        // POST: Fazenda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fazenda = await _context.Fazendas.SingleOrDefaultAsync(m => m.Id == id);
            _context.Fazendas.Remove(fazenda);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FazendaExists(int id)
        {
            return _context.Fazendas.Any(e => e.Id == id);
        }
    }
}
