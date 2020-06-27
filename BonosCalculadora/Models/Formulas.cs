using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.VisualBasic;
using static System.Math;

namespace BonosCalculadora.Models
{
    public class Formulas
    {
        public int FormulasId { get; set; }

        static public int DevolverFrecuenciaPago(string frecuencia)
        {
            if (frecuencia == "Semestral") return 180;
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
            if (frecuencia == "Quincenal") return 15;
            if (frecuencia == "Semestral") return 180;
            if (frecuencia == "Mensual") return 30;
            if (frecuencia == "Bimestral") return 60;
            if (frecuencia == "Trimestral") return 90;
            if (frecuencia == "Cuatrimestral") return 120;
            if (frecuencia == "Anual") return 360;
            else return 0;

        }

        //npa=numero de periodos por año
        static public int CalcularTotalPeriodos(int naños, int npa)
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
                   //Round redonde a 5 decimales
                nuevatasa = Round(valortasa, 5);
                return nuevatasa;
            }
            else if (tasa == "Nominal")
            {
                nuevatasa = Round(Pow(1 + valortasa / (diasAño / diasCapi), diasAño / diasCapi) - 1, 5);
                return nuevatasa;
            }
            else
            {
                return 0;
            }
        }

        //la tasa efectiva anual se transforma a tasas por periodos
        static public double CalcularTasaEfectivaDelPeriodo(double valortasa, double frec, double diasAño)
        {
            double tasa;
            tasa = Round(Pow(1 + valortasa, (frec / diasAño)) - 1, 5);
            return tasa;
        }

        //cok anual dividido en varios periodos
        static public double CalcularCokPeriodo(double cok, double frec, double dias)
        {
            double cokperiodo;
            cokperiodo = Pow(1 + cok, frec / dias) - 1;
            return cokperiodo;
        }

        //costes iniciales alterados al valor comercial
        static public double CalcularCostesInicialesEmisor(double pEst, double pCol, double pFlo, double pCAVA, double VCom)
        {
            double costes;
            costes = Round((pEst + pCol + pCAVA + pFlo) * VCom, 2);
            return costes;
        }
        //costes iniciales alterados al valor comercial
        static public double CalcularCostesInicalesBonista(double pFlo, double pCAVA, double VCom)
        {
            double costes;
            costes = Round((pFlo + pCAVA) * VCom, 2);
            return costes;
        }


        static public double cuotaFrances(double prestamo,double tep,int n)
        {
            double r=Round(Financial.Pmt(tep,n,prestamo),2);
            return r;

        }

        static public double Bono(int periodo, int totalperiodos,double vnom)
        {
            double bono = 0;
            if (periodo == 0)
            {
                bono= 0;
            }else if(periodo<= totalperiodos)
            {
                bono = vnom;
            }
            return bono;
        }
        //Todos
        static public double BonoIndexado(int periodo, int totalperiodos, double bono, double infperiodo)
        {
            double bonoindex = 0;
            if (periodo == 0)
            {
                bonoindex = 0;
            }
            else if (periodo <= totalperiodos)
            {
                bonoindex = Round(bono * (1 + infperiodo), 2);
            }
            return bonoindex;
        }

        //Todos
        static public double CalcularInteres(int periodo, int totalperiodos, double bonoindexado,double tep)
        {
            double interes = 0;
            if (periodo == 0)
            {
                interes =0;
            }
            else if (periodo <= totalperiodos)
            {
               interes = -Round(bonoindexado * tep, 2);
            }
            return interes;
        }

        static public double CuotaAmericano(double bono,int periodo,int totalperiodos,double interes,double amort)
        {
            double cuota = 0;
            if (periodo == 0) 
            {
                cuota = 0;
            }
            else if (periodo < totalperiodos)
            {
               cuota = Round(interes + amort,2);
            }
            else if (periodo == totalperiodos)
            {
                cuota = Round(-bono + interes,2);
            }
            
            return cuota;
        }

        static public double AmortizacionAleman( int periodo, int totalperiodos, double vnom)
        {
            double amort = 0;
            if (periodo == 0)
            {
                amort = 0;
            }
            else if (periodo <= totalperiodos)
            {
                amort = -Round(vnom/totalperiodos,2);
            }
            return amort;
        }
        static public double CuotaAleman(int periodo, int totalperiodos, double interes, double amort)
        {
            double cuota = 0;
            if (periodo == 0)
            {
                cuota = 0;
            }
            else if (periodo <= totalperiodos)
            {
                cuota = Round(interes + amort, 2);
            }
            return cuota;
        }

        static public double Escudo(int periodo, int totalperiodos,double interes)
        {
            double escudo=0;
            if (periodo == 0)
            {
                escudo= 0;
            }
            //0.30 significa el impuesto a la renta
            else if (periodo <= totalperiodos)
            {
                escudo = -Round(interes * 0.30, 2);
            }
            
            return escudo;
        }
        static public double FEmisor(int periodo, int totalperiodos, double cuota, double prima, double vcomercial, double costoinicial)
        {
            double femi = 0;
            if (periodo == 0)
            {
                femi = Round(vcomercial - costoinicial, 2);
            }
            else if (periodo < totalperiodos)
            {
                femi = cuota;
            }
            else if (periodo == totalperiodos)
            {
                femi = cuota + prima;
            }
            return femi;
        }
        static public double FEmisorEscudo(int periodo, int totalperiodos,double escudo,double femisor)
        {
            double femiescu = 0;
            if (periodo == 0)
            {
                femiescu = femisor;
            }
            else if (periodo <= totalperiodos)
            {
                femiescu = Round(escudo + femisor, 2);
            }
           
            return femiescu;

        }

        static public double FBonista(int periodo, int totalperiodos,double vcomercial, double costoinicial,double femisor)
        {
            double fbonista = 0;
            if (periodo == 0)
            {
                fbonista = -vcomercial - costoinicial;
            }
            else if (periodo <= totalperiodos)
            {
                fbonista = -femisor;
            }

            return fbonista;
        }
        static public double Prima(int periodo, int totalperiodos, double prima,double bonoindexado)
        {
            double primaaux = 0;
            if (periodo < totalperiodos)
            {
                primaaux = 0;
            }
            else if(periodo == totalperiodos)
            {
                primaaux = -Round(prima * bonoindexado, 2);
            }
            return primaaux;
                   
        }

        static public double AmortizacionAmericano(int periodo, int totalperiodos,double bono)
        {
            double amort = 0;
            if (periodo < totalperiodos)
            {
                amort = 0;
            }
            else if(periodo == totalperiodos)
            {
                amort = -bono;
            }
            return amort;

        }

        static public double AmortizacionFrances(int periodo, int totalperiodos, double cuota,double interes)
        {
            double amort = 0;
            if (periodo == 0)
            {
                amort = 0;
            }
            else if (periodo <= totalperiodos)
            {
                amort = Round(cuota-interes,2);
            }
            return amort;

        }

        //Hallando TIR para una serie de numeros
        static public double calculartir(double[] array)
        {

            double a = Round(Financial.IRR(ref array,0.01),4);
            return a;
        }
        //Hallando VAN para una serie de numeros
        static public double CalcularVAN(double tasa, double[] array)
        {
            double van = Round(Financial.NPV(tasa, ref array),2);
            return van;
        }

        //para calcular no se necesita el primer valor del array
        static public double[] ReduceTamaño(double[]array)
        {
            List<double> listaaux = array.ToList();
            listaaux.RemoveAt(0);
            double[] arregloaux = listaaux.ToArray();
            return arregloaux;     
        }





    }
}
