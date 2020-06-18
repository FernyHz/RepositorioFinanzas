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
    public class CalculadoraController : Controller
    {
        private readonly DbBonosContext _context;

        public CalculadoraController(DbBonosContext context)
        {
            _context = context;
        }

        // GET: Calculadora
        public async Task<IActionResult> Index()
        {
            var dbBonosContext = _context.Calculadora.Include(c => c.Capitalizacion).Include(c => c.Cliente).Include(c => c.DiasAño).Include(c => c.FrecuenciaPago).Include(c => c.MetodoPago).Include(c => c.TasaInteres);
            return View(await dbBonosContext.ToListAsync());
        }

        // GET: Calculadora/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calculadora = await _context.Calculadora
                .Include(c => c.Capitalizacion)
                .Include(c => c.Cliente)
                .Include(c => c.DiasAño)
                .Include(c => c.FrecuenciaPago)
                .Include(c => c.MetodoPago)
                .Include(c => c.TasaInteres)
                .FirstOrDefaultAsync(m => m.CalculadoraId == id);
            if (calculadora == null)
            {
                return NotFound();
            }

            return View(calculadora);
        }

        // GET: Calculadora/Create
        public IActionResult Create()
        {
            ViewData["CapitalizacionId"] = new SelectList(_context.Capitalizacion, "CapitalizacionId", "NCapitalizacion");
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "Apellidos");
            ViewData["DiasAñoId"] = new SelectList(_context.DiasAño, "DiasAñoId", "DiasAñoId");
            ViewData["FrecuenciaPagoId"] = new SelectList(_context.FrecuenciaPago, "FrecuenciaPagoId", "Tipofrecuencia");
            ViewData["MetodoPagoId"] = new SelectList(_context.MetodoPago, "MetodoPagoId", "TipoMetodo");
            ViewData["TasaInteresId"] = new SelectList(_context.TasaInteres, "TasaInteresId", "Tipotasa");
            return View();
        }

        // POST: Calculadora/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CalculadoraId,ClienteId,FrecuenciaPagoId,DiasAñoId,TasaInteresId,CapitalizacionId,MetodoPagoId,Vnominal,Vcomercial,NAños,Cok,ImRenta,FechaEmision,Prima,Estructuración,Colocación,Flotacion,Cavali")] Calculadora calculadora)
        {
            if (ModelState.IsValid)
            {
                _context.Add(calculadora);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CapitalizacionId"] = new SelectList(_context.Capitalizacion, "CapitalizacionId", "NCapitalizacion", calculadora.CapitalizacionId);
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "Apellidos", calculadora.ClienteId);
            ViewData["DiasAñoId"] = new SelectList(_context.DiasAño, "DiasAñoId", "DiasAñoId", calculadora.DiasAñoId);
            ViewData["FrecuenciaPagoId"] = new SelectList(_context.FrecuenciaPago, "FrecuenciaPagoId", "Tipofrecuencia", calculadora.FrecuenciaPagoId);
            ViewData["MetodoPagoId"] = new SelectList(_context.MetodoPago, "MetodoPagoId", "TipoMetodo", calculadora.MetodoPagoId);
            ViewData["TasaInteresId"] = new SelectList(_context.TasaInteres, "TasaInteresId", "Tipotasa", calculadora.TasaInteresId);
            return View(calculadora);
        }

        // GET: Calculadora/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calculadora = await _context.Calculadora.FindAsync(id);
            if (calculadora == null)
            {
                return NotFound();
            }
            ViewData["CapitalizacionId"] = new SelectList(_context.Capitalizacion, "CapitalizacionId", "NCapitalizacion", calculadora.CapitalizacionId);
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "Apellidos", calculadora.ClienteId);
            ViewData["DiasAñoId"] = new SelectList(_context.DiasAño, "DiasAñoId", "DiasAñoId", calculadora.DiasAñoId);
            ViewData["FrecuenciaPagoId"] = new SelectList(_context.FrecuenciaPago, "FrecuenciaPagoId", "Tipofrecuencia", calculadora.FrecuenciaPagoId);
            ViewData["MetodoPagoId"] = new SelectList(_context.MetodoPago, "MetodoPagoId", "TipoMetodo", calculadora.MetodoPagoId);
            ViewData["TasaInteresId"] = new SelectList(_context.TasaInteres, "TasaInteresId", "Tipotasa", calculadora.TasaInteresId);
            return View(calculadora);
        }

        // POST: Calculadora/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CalculadoraId,ClienteId,FrecuenciaPagoId,DiasAñoId,TasaInteresId,CapitalizacionId,MetodoPagoId,Vnominal,Vcomercial,NAños,Cok,ImRenta,FechaEmision,Prima,Estructuración,Colocación,Flotacion,Cavali")] Calculadora calculadora)
        {
            if (id != calculadora.CalculadoraId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(calculadora);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CalculadoraExists(calculadora.CalculadoraId))
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
            ViewData["CapitalizacionId"] = new SelectList(_context.Capitalizacion, "CapitalizacionId", "NCapitalizacion", calculadora.CapitalizacionId);
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ClienteId", "Apellidos", calculadora.ClienteId);
            ViewData["DiasAñoId"] = new SelectList(_context.DiasAño, "DiasAñoId", "DiasAñoId", calculadora.DiasAñoId);
            ViewData["FrecuenciaPagoId"] = new SelectList(_context.FrecuenciaPago, "FrecuenciaPagoId", "Tipofrecuencia", calculadora.FrecuenciaPagoId);
            ViewData["MetodoPagoId"] = new SelectList(_context.MetodoPago, "MetodoPagoId", "TipoMetodo", calculadora.MetodoPagoId);
            ViewData["TasaInteresId"] = new SelectList(_context.TasaInteres, "TasaInteresId", "Tipotasa", calculadora.TasaInteresId);
            return View(calculadora);
        }

        // GET: Calculadora/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calculadora = await _context.Calculadora
                .Include(c => c.Capitalizacion)
                .Include(c => c.Cliente)
                .Include(c => c.DiasAño)
                .Include(c => c.FrecuenciaPago)
                .Include(c => c.MetodoPago)
                .Include(c => c.TasaInteres)
                .FirstOrDefaultAsync(m => m.CalculadoraId == id);
            if (calculadora == null)
            {
                return NotFound();
            }

            return View(calculadora);
        }

        // POST: Calculadora/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var calculadora = await _context.Calculadora.FindAsync(id);
            _context.Calculadora.Remove(calculadora);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CalculadoraExists(int id)
        {
            return _context.Calculadora.Any(e => e.CalculadoraId == id);
        }
    }
}
