﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BonosCalculadora.Models;

namespace BonosCalculadora.Controllers
{
    public class CapitalizacionController : Controller
    {
        private readonly DbBonosContext _context;

        public CapitalizacionController(DbBonosContext context)
        {
            _context = context;
        }

        // GET: Capitalizacion
        public async Task<IActionResult> Index()
        {
            return View(await _context.Capitalizacion.ToListAsync());
        }

        // GET: Capitalizacion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var capitalizacion = await _context.Capitalizacion
                .FirstOrDefaultAsync(m => m.CapitalizacionId == id);
            if (capitalizacion == null)
            {
                return NotFound();
            }

            return View(capitalizacion);
        }

        // GET: Capitalizacion/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Capitalizacion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CapitalizacionId,TipoCapitalizacion")] Capitalizacion capitalizacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(capitalizacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(capitalizacion);
        }

        // GET: Capitalizacion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var capitalizacion = await _context.Capitalizacion.FindAsync(id);
            if (capitalizacion == null)
            {
                return NotFound();
            }
            return View(capitalizacion);
        }

        // POST: Capitalizacion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CapitalizacionId,TipoCapitalizacion")] Capitalizacion capitalizacion)
        {
            if (id != capitalizacion.CapitalizacionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(capitalizacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CapitalizacionExists(capitalizacion.CapitalizacionId))
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
            return View(capitalizacion);
        }

        // GET: Capitalizacion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var capitalizacion = await _context.Capitalizacion
                .FirstOrDefaultAsync(m => m.CapitalizacionId == id);
            if (capitalizacion == null)
            {
                return NotFound();
            }

            return View(capitalizacion);
        }

        // POST: Capitalizacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var capitalizacion = await _context.Capitalizacion.FindAsync(id);
            _context.Capitalizacion.Remove(capitalizacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CapitalizacionExists(int id)
        {
            return _context.Capitalizacion.Any(e => e.CapitalizacionId == id);
        }
    }
}
