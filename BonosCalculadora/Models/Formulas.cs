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

       // public static List<double> resultados()
       // {
       //     List<double> objetos = new List<double>();
       //     double ctp = CalcularTotalPeriodos(360, 180);
       //     double ccib = CalcularCostesInicalesBonista(0.5, 0.5, 0.7);
       //     objetos.Add(ctp);
       //     objetos.Add(ccib);
       //     return objetos;
       // }
     //  static public double el(double num)
     //   {
     //       double a;
     //       a = Math.Pow(num, 2);
     //       return a;
     //   }

        static public int DevolverFrecuenciaPago(string frecuencia)
        {
            if (frecuencia == "Semestral")  return 180;
            if (frecuencia == "Mensual") return 30;
            if (frecuencia == "Bimestral") return 60;
            if (frecuencia == "Trimestral") return 90;
            if (frecuencia == "Cuatrimestral") return 120;
            if (frecuencia == "Anual") return 360;
            else return 0;

        }

        static public int DevolverDiasCapitalizacion(string frecuencia)
        {
            if (frecuencia == "Diaria") return 1;
            if (frecuencia == "Quincenal") return 180;
            if (frecuencia == "Semestral") return 180;
            if (frecuencia == "Mensual") return 30;
            if (frecuencia == "Bimestral") return 60;
            if (frecuencia == "Trimestral") return 90;
            if (frecuencia == "Cuatrimestral") return 120;
            if (frecuencia == "Anual") return 360;
            else return 0;

        }

        static public int CalcularTotalPeriodos(int naños,int npa)
        {
            int periodos;
            periodos = naños * npa;
            return periodos;
        }
        static public int CalcularPeriodosporAño(int dias, int frecuencia)
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

                nuevatasa = Math.Round(valortasa,5);
                return nuevatasa;
            }
            else if (tasa == "Nominal")
            {
                nuevatasa = Math.Round(Math.Pow(1 + valortasa / (diasAño / diasCapi), diasAño / diasCapi) - 1,5);
                return nuevatasa;
            }
            else
            {
                return 0;
            }
        }

        static public double CalcularTasaEfectivaDelPeriodo(double valortasa, double frec, double diasAño)
        {
            double tasa;
            tasa = Math.Round(Math.Pow(1 + valortasa, (frec / diasAño))-1,5);
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
