﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BonosCalculadora.Models;
using System.Security.Cryptography.X509Certificates;
using static System.Math;


namespace BonosCalculadora.Controllers
{
    public class CalculadoraController : Controller
    {
        
        private readonly DbBonosContext _context;
        public double aux { get; set; }
        public double aux2 { get; set; }
        //para aplicarlo en el aleman hola hola
        //Hola com estas
        public double bonoconstante { get; set; }
        
        

        public CalculadoraController(DbBonosContext context)
        {
            _context = context;
        }
     
            
        // GET: Calculadora
        public async Task<IActionResult> Index()
        {
            var dbBonosContext = _context.Calculadora.Include(c => c.Capitalizacion).Include(c => c.FrecuenciaPago).Include(c => c.MetodoPago).Include(c => c.TasaInteres);
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
                .Include(c => c.FrecuenciaPago)
                .Include(c => c.MetodoPago)
                .Include(c => c.TasaInteres)
                .FirstOrDefaultAsync(m => m.CalculadoraId == id);
            if (calculadora == null)
            {
                return NotFound();
            }

            //Para resultados de Estruct. del Bono
            int frec = Formulas.DevolverFrecuenciaPago(calculadora.FrecuenciaPago.Tipofrecuencia);
            int dc = Formulas.DevolverDiasCapitalizacion(calculadora.Capitalizacion.TipoCapitalizacion);
            int ctp = Formulas.CalcularPeriodosporAño(calculadora.DiasAño, frec);
            int tp = Formulas.CalcularTotalPeriodos(calculadora.NAños, ctp);
            double efa = Formulas.CalcularTasaEfectivaAnual(calculadora.TasaInteres.TipoTasa, Double.Parse(calculadora.TasaDeInteres), calculadora.DiasAño, dc);
            double efp = Formulas.CalcularTasaEfectivaDelPeriodo(efa, frec, calculadora.DiasAño);
            double ck = Formulas.CalcularCokPeriodo(Double.Parse(calculadora.Cok), frec, calculadora.DiasAño);
            double cie = Formulas.CalcularCostesInicialesEmisor(Double.Parse(calculadora.Estructuración), Double.Parse(calculadora.Colocación)
            , Double.Parse(calculadora.Flotacion), Double.Parse(calculadora.Cavali), Double.Parse(calculadora.Vcomercial));
            double cib = Formulas.CalcularCostesInicalesBonista(Double.Parse(calculadora.Flotacion), Double.Parse(calculadora.Cavali), Double.Parse(calculadora.Vcomercial));
            ViewBag.Capi = dc;
            ViewBag.Peri = ctp;
            ViewBag.Frec = frec;
            ViewBag.PeriT = tp;
            ViewBag.Tasa = efa;
            ViewBag.TasaP = efp;
            ViewBag.CokP = Round(ck,5);
            ViewBag.Cie = cie;
            ViewBag.Cib = cib;
            //variables
            double vnom = Double.Parse(calculadora.Vnominal);
            double fbonista = 0;
            List<Objeto> hi = new List<Objeto>();
            double[] arraytiremi = new double[tp + 1];
            double[] arraytiremiescu = new double[tp + 1];
            double[] arraytirbon = new double[tp + 1];
            double[] arrayvan = new double[tp + 1];
           
            if (calculadora.MetodoPago.TipoMetodo == "Americano")
            {
                aux = 0;
                
                for (int i = 0; i <= tp; i++)
                {
                    Objeto ob = new Objeto();
                    ob.numero = i;
                    ob.infanual = 0;
                    ob.infperiodo = 0;
                   
                    ob.bono = Formulas.Bono(i, tp, Double.Parse(calculadora.Vnominal));
                    ob.bonoindexado = Formulas.BonoIndexado(i, tp, ob.bono, ob.infperiodo);
                    ob.interes = Formulas.CalcularInteres(i, tp, ob.bonoindexado, efp);
                    ob.cuota = Formulas.CuotaAmericano(ob.bono, i, tp, ob.interes, ob.amort);
                    ob.amort = Formulas.AmortizacionAmericano(i, tp, ob.bono);
                    ob.prima = Formulas.Prima(i, tp, Double.Parse(calculadora.Prima), vnom);
                    ob.escudo = Formulas.Escudo(i, tp, ob.interes);
                    ob.femisor = Formulas.FEmisor(i, tp, ob.cuota, ob.prima, Double.Parse(calculadora.Vcomercial), cie);
                    ob.femiescu = Formulas.FEmisorEscudo(i, tp, ob.escudo, ob.femisor);
                    ob.fbonista = Formulas.FBonista(i, tp, Double.Parse(calculadora.Vcomercial), cib, ob.femisor);
                    if (i == 0) { fbonista = ob.fbonista; }
                    arraytiremi[i] = ob.femisor;
                    arraytirbon[i] = ob.fbonista;
                    arraytiremiescu[i] = ob.femiescu;
                    arrayvan[i] = ob.fbonista; 
                    hi.Add(ob);
                }
                double tirboni = Formulas.calculartir(arraytirbon);
                double tiremi = Formulas.calculartir(arraytiremi);
                double tiremiescu = Formulas.calculartir(arraytiremiescu);

                double[] arrayvanreducido = Formulas.ReduceTamaño(arrayvan);
                double van = Round(Formulas.CalcularVAN(ck,arrayvanreducido),2);
                double fb = Round(fbonista + van,2);
                double tcabonista = Formulas.CalcularTCEA(tirboni, calculadora.DiasAño, frec);
                double tcaemisor = Formulas.CalcularTCEA(tiremi, calculadora.DiasAño, frec);
                double tcaemisorescu = Formulas.CalcularTCEA(tiremiescu, calculadora.DiasAño, frec);

                ViewBag.vna = van;
                ViewBag.fbon = fb;
                ViewBag.tcboni = tcabonista;
                ViewBag.tcemi = tcaemisor;
                ViewBag.tcemiescu = tcaemisorescu;
            }
            else if (calculadora.MetodoPago.TipoMetodo == "Aleman")
            {
                //para calcular la bajada del saldo inicial del bono
                aux = vnom;
                for (int i = 0; i <= tp; i++)
                {
                    Objeto ob = new Objeto();
                    ob.numero = i;
                    ob.infanual = 0;
                    ob.infperiodo = 0;
                    if (i == 0) { ob.bono = 0; } else { ob.bono = Round(aux, 2); }
                    ob.bonoindexado = Formulas.BonoIndexado(i, tp, ob.bono, ob.infperiodo);
                    ob.interes = Formulas.CalcularInteres(i, tp, ob.bonoindexado, efp);
                    ob.amort = Formulas.AmortizacionAleman(i, tp, vnom);
                    ob.cuota = Formulas.CuotaAleman(i, tp, ob.interes, ob.amort);
                    ob.prima = Formulas.Prima(i, tp, Double.Parse(calculadora.Prima), vnom);
                    ob.escudo = Formulas.Escudo(i, tp, ob.interes);
                    ob.femisor = Formulas.FEmisor(i, tp, ob.cuota, ob.prima, Double.Parse(calculadora.Vcomercial), cie);
                    ob.femiescu = Formulas.FEmisorEscudo(i, tp, ob.escudo, ob.femisor);
                    ob.fbonista = Formulas.FBonista(i, tp, Double.Parse(calculadora.Vcomercial), cib, ob.femisor);
                    if (i == 0) { fbonista = ob.fbonista; }
                    //es + porque la amort esta en negativo
                    aux += ob.amort;
                    arraytiremi[i] = ob.femisor;
                    arraytirbon[i] = ob.fbonista;
                    arraytiremiescu[i] = ob.femiescu;
                    arrayvan[i] = ob.fbonista;
                    hi.Add(ob);
                }
                double tirboni = Formulas.calculartir(arraytirbon);
                double tiremi = Formulas.calculartir(arraytiremi);
                double tiremiescu = Formulas.calculartir(arraytiremiescu);

                double[] arrayvanreducido = Formulas.ReduceTamaño(arrayvan);
                double van = Round(Formulas.CalcularVAN(ck, arrayvanreducido), 2);
                double fb = Round(fbonista + van, 2);
                double tcabonista = Formulas.CalcularTCEA(tirboni, calculadora.DiasAño, frec);
                double tcaemisor = Formulas.CalcularTCEA(tiremi, calculadora.DiasAño, frec);
                double tcaemisorescu = Formulas.CalcularTCEA(tiremiescu, calculadora.DiasAño, frec);

                ViewBag.vna = van;
                ViewBag.fbon = fb;
                ViewBag.tcboni = tcabonista;
                ViewBag.tcemi = tcaemisor;
                ViewBag.tcemiescu = tcaemisorescu;
            }
            else if (calculadora.MetodoPago.TipoMetodo == "Frances")
            {
                aux = vnom;
                for (int i = 0; i <= tp; i++)
                {
                    Objeto ob = new Objeto();

                    ob.numero = i;
                    ob.infanual = 0;
                    ob.infperiodo = 0;
                    if (i == 0) { ob.bono = 0; } else { ob.bono = Round(aux, 2); }
                    ob.bonoindexado = Formulas.BonoIndexado(i, tp, ob.bono, ob.infperiodo);
                    ob.interes = Formulas.CalcularInteres(i, tp, ob.bonoindexado, efp);
                    ob.cuota = Formulas.cuotaFrances(i,tp,vnom, efp, tp); ;
                    ob.amort = Formulas.AmortizacionFrances(i, tp, ob.cuota, ob.interes);
                    ob.prima = Formulas.Prima(i, tp, Double.Parse(calculadora.Prima), vnom);
                    ob.escudo = Formulas.Escudo(i, tp, ob.interes);
                    ob.femisor = Formulas.FEmisor(i, tp, ob.cuota, ob.prima, Double.Parse(calculadora.Vcomercial), cie);
                    ob.femiescu = Formulas.FEmisorEscudo(i, tp, ob.escudo, ob.femisor);
                    ob.fbonista = Formulas.FBonista(i, tp, Double.Parse(calculadora.Vcomercial), cib, ob.femisor);
                    if (i == 0) { fbonista = ob.fbonista; }
                    aux += ob.amort;
                    arraytiremi[i] = ob.femisor;
                    arraytirbon[i] = ob.fbonista;
                    arraytiremiescu[i] = ob.femiescu;
                    arrayvan[i] = ob.fbonista;

                    hi.Add(ob);
                }

                double tirboni = Formulas.calculartir(arraytirbon);
                double tiremi = Formulas.calculartir(arraytiremi);
                double tiremiescu = Formulas.calculartir(arraytiremiescu);

                double[] arrayvanreducido = Formulas.ReduceTamaño(arrayvan);
                double van = Round(Formulas.CalcularVAN(ck, arrayvanreducido), 2);
                double fb = Round(fbonista + van, 2);
                double tcabonista = Formulas.CalcularTCEA(tirboni, calculadora.DiasAño, frec);
                double tcaemisor = Formulas.CalcularTCEA(tiremi, calculadora.DiasAño, frec);
                double tcaemisorescu = Formulas.CalcularTCEA(tiremiescu, calculadora.DiasAño, frec);

                ViewBag.vna = van;
                ViewBag.fbon = fb;
                ViewBag.tcboni = tcabonista;
                ViewBag.tcemi = tcaemisor;
                ViewBag.tcemiescu = tcaemisorescu;
            }
            ViewBag.listahi = hi;
            return View(calculadora);
        }

        // GET: Calculadora/Create
        public IActionResult Create()
        {
            ViewData["CapitalizacionId"] = new SelectList(_context.Capitalizacion, "CapitalizacionId", "TipoCapitalizacion");
            ViewData["FrecuenciaPagoId"] = new SelectList(_context.FrecuenciaPago, "FrecuenciaPagoId", "Tipofrecuencia");
            ViewData["MetodoPagoId"] = new SelectList(_context.MetodoPago, "MetodoPagoId", "TipoMetodo");
            ViewData["TasaInteresId"] = new SelectList(_context.TasaInteres, "TasaInteresId", "TipoTasa");
            return View();
        }

        // POST: Calculadora/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CalculadoraId,FrecuenciaPagoId,TasaInteresId,CapitalizacionId,MetodoPagoId,Vnominal,Vcomercial,TasaDeInteres,NAños,DiasAño,Cok,FechaEmision,Prima,Estructuración,Colocación,Flotacion,Cavali")] Calculadora calculadora)
        {
            if (ModelState.IsValid)
            {
                _context.Add(calculadora);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CapitalizacionId"] = new SelectList(_context.Capitalizacion, "CapitalizacionId", "TipoCapitalizacion", calculadora.CapitalizacionId);
            ViewData["FrecuenciaPagoId"] = new SelectList(_context.FrecuenciaPago, "FrecuenciaPagoId", "Tipofrecuencia", calculadora.FrecuenciaPagoId);
            ViewData["MetodoPagoId"] = new SelectList(_context.MetodoPago, "MetodoPagoId", "TipoMetodo", calculadora.MetodoPagoId);
            ViewData["TasaInteresId"] = new SelectList(_context.TasaInteres, "TasaInteresId", "TipoTasa", calculadora.TasaInteresId);
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
            ViewData["CapitalizacionId"] = new SelectList(_context.Capitalizacion, "CapitalizacionId", "TipoCapitalizacion", calculadora.CapitalizacionId);
            ViewData["FrecuenciaPagoId"] = new SelectList(_context.FrecuenciaPago, "FrecuenciaPagoId", "Tipofrecuencia", calculadora.FrecuenciaPagoId);
            ViewData["MetodoPagoId"] = new SelectList(_context.MetodoPago, "MetodoPagoId", "TipoMetodo", calculadora.MetodoPagoId);
            ViewData["TasaInteresId"] = new SelectList(_context.TasaInteres, "TasaInteresId", "TipoTasa", calculadora.TasaInteresId);
            return View(calculadora);
        }

        // POST: Calculadora/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CalculadoraId,FrecuenciaPagoId,TasaInteresId,CapitalizacionId,MetodoPagoId,Vnominal,Vcomercial,TasaDeInteres,NAños,DiasAño,Cok,FechaEmision,Prima,Estructuración,Colocación,Flotacion,Cavali")] Calculadora calculadora)
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
            ViewData["CapitalizacionId"] = new SelectList(_context.Capitalizacion, "CapitalizacionId", "TipoCapitalizacion", calculadora.CapitalizacionId);
            ViewData["FrecuenciaPagoId"] = new SelectList(_context.FrecuenciaPago, "FrecuenciaPagoId", "Tipofrecuencia", calculadora.FrecuenciaPagoId);
            ViewData["MetodoPagoId"] = new SelectList(_context.MetodoPago, "MetodoPagoId", "TipoMetodo", calculadora.MetodoPagoId);
            ViewData["TasaInteresId"] = new SelectList(_context.TasaInteres, "TasaInteresId", "TipoTasa", calculadora.TasaInteresId);
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
