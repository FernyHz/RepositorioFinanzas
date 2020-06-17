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
    public class MetodoPagoesController : Controller
    {
        private readonly DbBonosContext _context;

        public MetodoPagoesController(DbBonosContext context)
        {
            _context = context;
        }

        // GET: MetodoPagoes
        public async Task<IActionResult> Index()
        {
            var dbBonosContext = _context.MetodoPago.Include(m => m.Calculadora);
            return View(await dbBonosContext.ToListAsync());
        }

        // GET: MetodoPagoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var metodoPago = await _context.MetodoPago
                .Include(m => m.Calculadora)
                .FirstOrDefaultAsync(m => m.MetodoPagoId == id);
            if (metodoPago == null)
            {
                return NotFound();
            }

            return View(metodoPago);
        }

        // GET: MetodoPagoes/Create
        public IActionResult Create()
        {
            ViewData["CalculadoraId"] = new SelectList(_context.Calculadora, "CalculadoraId", "CalculadoraId");
            return View();
        }

        // POST: MetodoPagoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MetodoPagoId,CalculadoraId,TipoMetodo")] MetodoPago metodoPago)
        {
            if (ModelState.IsValid)
            {
                _context.Add(metodoPago);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CalculadoraId"] = new SelectList(_context.Calculadora, "CalculadoraId", "CalculadoraId", metodoPago.CalculadoraId);
            return View(metodoPago);
        }

        // GET: MetodoPagoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var metodoPago = await _context.MetodoPago.FindAsync(id);
            if (metodoPago == null)
            {
                return NotFound();
            }
            ViewData["CalculadoraId"] = new SelectList(_context.Calculadora, "CalculadoraId", "CalculadoraId", metodoPago.CalculadoraId);
            return View(metodoPago);
        }

        // POST: MetodoPagoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MetodoPagoId,CalculadoraId,TipoMetodo")] MetodoPago metodoPago)
        {
            if (id != metodoPago.MetodoPagoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(metodoPago);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MetodoPagoExists(metodoPago.MetodoPagoId))
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
            ViewData["CalculadoraId"] = new SelectList(_context.Calculadora, "CalculadoraId", "CalculadoraId", metodoPago.CalculadoraId);
            return View(metodoPago);
        }

        // GET: MetodoPagoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var metodoPago = await _context.MetodoPago
                .Include(m => m.Calculadora)
                .FirstOrDefaultAsync(m => m.MetodoPagoId == id);
            if (metodoPago == null)
            {
                return NotFound();
            }

            return View(metodoPago);
        }

        // POST: MetodoPagoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var metodoPago = await _context.MetodoPago.FindAsync(id);
            _context.MetodoPago.Remove(metodoPago);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MetodoPagoExists(int id)
        {
            return _context.MetodoPago.Any(e => e.MetodoPagoId == id);
        }
    }
}
