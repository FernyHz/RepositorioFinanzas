using System;
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
        //para aplicarlo en el aleman
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
            int npa = Formulas.CalcularTotalPeriodos(calculadora.NAños, ctp);
            double efa = Formulas.CalcularTasaEfectivaAnual(calculadora.TasaInteres.TipoTasa, Double.Parse(calculadora.TasaDeInteres), calculadora.DiasAño, dc);
            double efp = Formulas.CalcularTasaEfectivaDelPeriodo(efa, frec, calculadora.DiasAño);
            double ck = Formulas.CalcularCokPeriodo(Double.Parse(calculadora.Cok), frec, calculadora.DiasAño);
            double cie = Formulas.CalcularCostesInicialesEmisor(Double.Parse(calculadora.Estructuración), Double.Parse(calculadora.Colocación)
            , Double.Parse(calculadora.Flotacion), Double.Parse(calculadora.Cavali), Double.Parse(calculadora.Vcomercial));
            double cib = Formulas.CalcularCostesInicalesBonista(Double.Parse(calculadora.Flotacion), Double.Parse(calculadora.Cavali), Double.Parse(calculadora.Vcomercial));
          //  double o = Formulas.tir();
          //   double o = Formulas.cuotaFrances(1440000, 0.044030651, 8);
            ViewBag.Capi = dc;
            ViewBag.Peri = ctp;
            ViewBag.Frec = frec;
            ViewBag.PeriT = npa;
            ViewBag.Tasa = efa;
            ViewBag.TasaP = efp;
            ViewBag.CokP = ck;
            ViewBag.Cie = cie;
            ViewBag.Cib = cib;
           // ViewBag.c = o;

            //variables
            double flujoemi = Double.Parse(calculadora.Vcomercial) - cie;
            double flujobonista = -(Double.Parse(calculadora.Vcomercial)) - cib;
            double vnom = Double.Parse(calculadora.Vnominal);
            List<Objeto> hi = new List<Objeto>();
            if (calculadora.MetodoPago.TipoMetodo == "Americano")
            {
                // ola = 0;
                aux = 0;
                double[] arraytir = new double[npa+1];

                for (int i = 0; i <= npa; i++)
                {
                    Objeto ob = new Objeto();

                    ob.numero = i;
                    ob.infanual = 0;
                    ob.infperiodo = 0;
                    ob.bono = Formulas.Bono(i, npa, Double.Parse(calculadora.Vnominal));
                    ob.bonoindexado = Formulas.BonoIndexado(i, npa, ob.bono, ob.bonoindexado);
                    ob.interes = Formulas.CalcularInteres(i, npa, ob.bonoindexado, efp);
                    ob.cuota = Formulas.CuotaAmericano(ob.bono, i, npa, ob.interes, ob.amort);
                    ob.amort = Formulas.AmortizacionAmericano(i, npa, ob.bono);
                    ob.prima = Formulas.Prima(i, npa, Double.Parse(calculadora.Prima), ob.bonoindexado);
                    ob.escudo = Formulas.Escudo(i, npa, ob.interes);
                    ob.femisor = Formulas.FEmisor(i, npa, ob.cuota, ob.prima, Double.Parse(calculadora.Vcomercial), cie); ;
                    ob.femiescu = Formulas.FEmisorEscudo(i, npa, ob.escudo, ob.femisor);
                    ob.fbonista = Formulas.FBonista(i, npa, Double.Parse(calculadora.Vcomercial), cib, ob.femisor); 
                    hi.Add(ob);
                    arraytir[i] = ob.fbonista;
                }
               // ViewBag.listahi = hi;
               double tir =Round(Formulas.calculartir(arraytir),4);
               ViewBag.t = tir;
            }
            else if (calculadora.MetodoPago.TipoMetodo == "Aleman")
            {
                //para calcular la bajada del saldo inicial del bono
                aux = vnom;             
                for (int i = 0; i <= npa; i++)
                {                 
                    Objeto ob = new Objeto();
                    if (i <= npa) 
                    {
                        if (i == 0)
                        {
                            ob.numero = 0;
                            ob.infanual = 0;
                            ob.infperiodo = 0;
                            ob.bono = 0;
                            ob.bonoindexado = 0;
                            ob.interes = 0;
                            ob.cuota = 0;
                            ob.amort = 0;
                            ob.prima = 0;
                            ob.escudo = 0;
                            ob.femisor = flujoemi;
                            ob.femiescu = flujoemi;
                            ob.fbonista = flujobonista;
                            // ola += ob.escudo;
                        }
                        else
                        {
                            ob.numero = i;
                            ob.infanual = 0;
                            ob.infperiodo = 0;
                            ob.bono = aux;
                            ob.bonoindexado = Math.Round(ob.bono * (1 + ob.infperiodo), 2);
                            ob.interes = -Math.Round(ob.bonoindexado * efp, 2);
                            ob.amort = -(vnom / npa);
                            ob.cuota = Math.Round(ob.interes + ob.amort, 2);
                            if (i == npa) { ob.prima = -Math.Round(Double.Parse(calculadora.Prima) * vnom, 2); }
                            else { ob.prima = 0; }
                            ob.escudo = -Math.Round(ob.interes * 0.30, 2);
                            if (i == npa) { ob.femisor = ob.cuota + ob.prima; } else { ob.femisor = ob.cuota; }                                
                            ob.femiescu = Math.Round(ob.escudo + ob.femisor, 2);
                            ob.fbonista = -ob.femisor;
                            //es + porque la amort esta en negativo
                            aux +=ob.amort;
                                 
                        }                   
                    }
                    hi.Add(ob);
                }             
             //   ViewBag.listahi = hi;
            }
            else if (calculadora.MetodoPago.TipoMetodo == "Frances")
            {
                aux = vnom;
                for (int i = 0; i <= npa; i++)
                {
                    Objeto ob = new Objeto();
                    if (i <= npa)
                    {
                        if (i == 0)
                        {
                            ob.numero = 0;
                            ob.infanual = 0;
                            ob.infperiodo = 0;
                            ob.bono = 0;
                            ob.bonoindexado = 0;
                            ob.interes = 0;
                            ob.cuota = 0;
                            ob.amort = 0;
                            ob.prima = 0;
                            ob.escudo = 0;
                            ob.femisor = flujoemi;
                            ob.femiescu = flujoemi;
                            ob.fbonista = flujobonista;
                        }
                        else
                        {
                            ob.numero = i;
                            ob.infanual = 0;
                            ob.infperiodo = 0;
                            ob.bono = Round(aux,2);
                            ob.bonoindexado = Round(ob.bono * (1 + ob.infperiodo), 2);
                            ob.interes = -Round(ob.bonoindexado * efp, 2);
                            ob.cuota = Round(Formulas.cuotaFrances(vnom, efp, npa),2); ;
                            ob.amort = Round(ob.cuota-ob.interes, 2);
                            if (i == npa) { ob.prima = -Math.Round(Double.Parse(calculadora.Prima) * vnom, 2); }
                            else { ob.prima = 0; }
                            ob.escudo = -Math.Round(ob.interes * 0.30, 2);
                            if (i == npa) { ob.femisor = ob.cuota + ob.prima; } else { ob.femisor = ob.cuota; }
                            ob.femiescu = Math.Round(ob.escudo + ob.femisor, 2);
                            ob.fbonista = -ob.femisor;
                            aux += ob.amort;
                        }
                    }
                    hi.Add(ob);
                }
               
            }
            ViewBag.listahi = hi;
            //ViewBag.a = ola;
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
