using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace BonosCalculadora.Models
{
    public class Formulas
    {
        public int FormulasId { get; set; }
     

        static public int CalcularTotalPeriodos(int dias, int frecuencia)
        {
            int periodos;
            periodos = dias / frecuencia;
            return periodos;
        }
        

       static public double CalcularTasaEfectivaAnual(string tasa, double valortasa, int diasAño, int diasCapi)
        {
            double nuevatasa;
            if (tasa == "Efectiva")
            {

                nuevatasa = valortasa;
                return nuevatasa;
            }
            else if (tasa == "Nominal")
            {
                nuevatasa = Math.Pow(1 + valortasa / (diasAño / diasCapi), diasAño / diasCapi);
                return nuevatasa;
            }
            else
            {
                return 0;
            }
        }

       static public double CalcularTasaEfectivaDelPeriodo(double valortasa, int frec, int diasAño)
        {
            double tasa;
            tasa = Math.Pow(1 + valortasa, frec / diasAño);
            return tasa;
        }
       static public double CalcularCokPeriodo(double cok, int frec, int dias)
        {
            double cokperiodo;
            cokperiodo = Math.Pow(1 + cok, frec / dias);
            return cokperiodo;
        }
        static public double CalcularCostesInicialesEmisor(double pEst, double pCol, double pFlo, double pCAVA,double VCom)
        {
            double costes;
            costes = (pEst + pCol + pCAVA + pFlo) * VCom;
            return costes;
        }

        static public double CalcularCostesInicalesBonista(double pFlo, double pCAVA, double VCom)
        {
            double costes;
            costes = (pFlo + pCAVA) * VCom;
            return costes;
        }



    }
}
