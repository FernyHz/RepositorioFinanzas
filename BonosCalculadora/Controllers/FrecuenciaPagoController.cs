using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BonosCalculadora.Models;

namespace BonosCalculadora.Controllers
{
    public class FrecuenciaPagoController : Controller
    {
        private readonly DbBonosContext _context;

        public FrecuenciaPagoController(DbBonosContext context)
        {
            _context = context;
        }

        // GET: FrecuenciaPago
        public async Task<IActionResult> Index()
        {
            return View(await _context.FrecuenciaPago.ToListAsync());
        }

        // GET: FrecuenciaPago/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var frecuenciaPago = await _context.FrecuenciaPago
                .FirstOrDefaultAsync(m => m.FrecuenciaPagoId == id);
            if (frecuenciaPago == null)
            {
                return NotFound();
            }

            return View(frecuenciaPago);
        }

        // GET: FrecuenciaPago/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FrecuenciaPago/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FrecuenciaPagoId,Tipofrecuencia,Diasfrecuencia")] FrecuenciaPago frecuenciaPago)
        {
            if (ModelState.IsValid)
            {
                _context.Add(frecuenciaPago);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(frecuenciaPago);
        }

        // GET: FrecuenciaPago/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var frecuenciaPago = await _context.FrecuenciaPago.FindAsync(id);
            if (frecuenciaPago == null)
            {
                return NotFound();
            }
            return View(frecuenciaPago);
        }

        // POST: FrecuenciaPago/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FrecuenciaPagoId,Tipofrecuencia,Diasfrecuencia")] FrecuenciaPago frecuenciaPago)
        {
            if (id != frecuenciaPago.FrecuenciaPagoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(frecuenciaPago);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FrecuenciaPagoExists(frecuenciaPago.FrecuenciaPagoId))
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
            return View(frecuenciaPago);
        }

        // GET: FrecuenciaPago/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var frecuenciaPago = await _context.FrecuenciaPago
                .FirstOrDefaultAsync(m => m.FrecuenciaPagoId == id);
            if (frecuenciaPago == null)
            {
                return NotFound();
            }

            return View(frecuenciaPago);
        }

        // POST: FrecuenciaPago/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var frecuenciaPago = await _context.FrecuenciaPago.FindAsync(id);
            _context.FrecuenciaPago.Remove(frecuenciaPago);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FrecuenciaPagoExists(int id)
        {
            return _context.FrecuenciaPago.Any(e => e.FrecuenciaPagoId == id);
        }
    }
}
