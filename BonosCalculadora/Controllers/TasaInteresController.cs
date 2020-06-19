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
    public class TasaInteresController : Controller
    {
        private readonly DbBonosContext _context;

        public TasaInteresController(DbBonosContext context)
        {
            _context = context;
        }

        // GET: TasaInteres
        public async Task<IActionResult> Index()
        {
            return View(await _context.TasaInteres.ToListAsync());
        }

        // GET: TasaInteres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tasaInteres = await _context.TasaInteres
                .FirstOrDefaultAsync(m => m.TasaInteresId == id);
            if (tasaInteres == null)
            {
                return NotFound();
            }

            return View(tasaInteres);
        }

        // GET: TasaInteres/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TasaInteres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TasaInteresId,TipoTasa")] TasaInteres tasaInteres)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tasaInteres);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tasaInteres);
        }

        // GET: TasaInteres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tasaInteres = await _context.TasaInteres.FindAsync(id);
            if (tasaInteres == null)
            {
                return NotFound();
            }
            return View(tasaInteres);
        }

        // POST: TasaInteres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TasaInteresId,TipoTasa")] TasaInteres tasaInteres)
        {
            if (id != tasaInteres.TasaInteresId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tasaInteres);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TasaInteresExists(tasaInteres.TasaInteresId))
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
            return View(tasaInteres);
        }

        // GET: TasaInteres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tasaInteres = await _context.TasaInteres
                .FirstOrDefaultAsync(m => m.TasaInteresId == id);
            if (tasaInteres == null)
            {
                return NotFound();
            }

            return View(tasaInteres);
        }

        // POST: TasaInteres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tasaInteres = await _context.TasaInteres.FindAsync(id);
            _context.TasaInteres.Remove(tasaInteres);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TasaInteresExists(int id)
        {
            return _context.TasaInteres.Any(e => e.TasaInteresId == id);
        }
    }
}
