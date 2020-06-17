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
    public class DiasAñoController : Controller
    {
        private readonly DbBonosContext _context;

        public DiasAñoController(DbBonosContext context)
        {
            _context = context;
        }

        // GET: DiasAño
        public async Task<IActionResult> Index()
        {
            var dbBonosContext = _context.DiasAño.Include(d => d.Calculadora);
            return View(await dbBonosContext.ToListAsync());
        }

        // GET: DiasAño/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diasAño = await _context.DiasAño
                .Include(d => d.Calculadora)
                .FirstOrDefaultAsync(m => m.DiasAñoId == id);
            if (diasAño == null)
            {
                return NotFound();
            }

            return View(diasAño);
        }

        // GET: DiasAño/Create
        public IActionResult Create()
        {
            ViewData["CalculadoraId"] = new SelectList(_context.Calculadora, "CalculadoraId", "CalculadoraId");
            return View();
        }

        // POST: DiasAño/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DiasAñoId,CalculadoraId,Dias")] DiasAño diasAño)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diasAño);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CalculadoraId"] = new SelectList(_context.Calculadora, "CalculadoraId", "CalculadoraId", diasAño.CalculadoraId);
            return View(diasAño);
        }

        // GET: DiasAño/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diasAño = await _context.DiasAño.FindAsync(id);
            if (diasAño == null)
            {
                return NotFound();
            }
            ViewData["CalculadoraId"] = new SelectList(_context.Calculadora, "CalculadoraId", "CalculadoraId", diasAño.CalculadoraId);
            return View(diasAño);
        }

        // POST: DiasAño/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DiasAñoId,CalculadoraId,Dias")] DiasAño diasAño)
        {
            if (id != diasAño.DiasAñoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diasAño);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiasAñoExists(diasAño.DiasAñoId))
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
            ViewData["CalculadoraId"] = new SelectList(_context.Calculadora, "CalculadoraId", "CalculadoraId", diasAño.CalculadoraId);
            return View(diasAño);
        }

        // GET: DiasAño/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diasAño = await _context.DiasAño
                .Include(d => d.Calculadora)
                .FirstOrDefaultAsync(m => m.DiasAñoId == id);
            if (diasAño == null)
            {
                return NotFound();
            }

            return View(diasAño);
        }

        // POST: DiasAño/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var diasAño = await _context.DiasAño.FindAsync(id);
            _context.DiasAño.Remove(diasAño);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiasAñoExists(int id)
        {
            return _context.DiasAño.Any(e => e.DiasAñoId == id);
        }
    }
}
