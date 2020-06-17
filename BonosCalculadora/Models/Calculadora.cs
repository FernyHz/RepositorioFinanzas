using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BonosCalculadora.Models
{

    public partial class Calculadora
    {
        public int CalculadoraId { get; set; }
        public int ClienteId { get; set; }
       // public int FrecuenciaPagoId { get; set; }
       // public int DiasAñoId { get; set; }
       // public int TasaInteresId { get; set; }
       // public int CapitalizacionId { get; set; }
       // public int MetodoPagoId { get; set; }

        //DEL BONO
        [Required(ErrorMessage = "Dato de entrada requerido")]
        public double Vnominal { get; set; }
        [Required(ErrorMessage = "Dato de entrada requerido")]
        public double Vcomercial { get; set; }
        [Required(ErrorMessage = "Numero de años requerido")]
        public int NAños { get; set; }
        [Required(ErrorMessage = "Tasa de descuento anual(COK) requerida")]
        public double Cok { get; set; }
        [Required(ErrorMessage = "Impuesto a la renta es requerido")]
        public double ImRenta { get; set; }

        [Required(ErrorMessage = "Fecha y hora son datos requeridos")]
        [Display(Name = "Fecha y Hora")]
        public DateTime FechaEmision { get; set; }

        //DE LOS COSTES/GASTOS INICIALES
        public double Prima { get; set; }
        public double Estructuración { get; set; }
        public double Colocación { get; set; }
        public double Flotacion { get; set; }
        public double Cavali { get; set; }


        public virtual ICollection<FrecuenciaPago> FrecuenciaPago { get; set; }
        public virtual ICollection<DiasAño> DiasAño { get; set; }
        public virtual ICollection<TasaInteres> TasaInteres { get; set; }
        public virtual ICollection<Capitalizacion> Capitalizacion { get; set; }
        public virtual ICollection<MetodoPago> MetodoPago { get; set; }

        public virtual Cliente Cliente { get; set; }

     


    }
}
