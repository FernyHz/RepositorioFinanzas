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
        [Required(ErrorMessage = "Elija metodo de pago")]
        [Display(Name = "Frecuencia de Pago")]
        public int FrecuenciaPagoId { get; set; }
        [Required(ErrorMessage = "Tipo de Tasa de Interes es requerida")]
        [Display(Name = "Tipo de Tasa de Interes")]
        public int TasaInteresId { get; set; }
        [Required(ErrorMessage = "Capitalizacion es requerida")]
        [Display(Name = "Capitalizacion")]
        public int CapitalizacionId { get; set; }
        [Required(ErrorMessage = "Elija Metodo de pago")]
        [Display(Name = "Metodo de Pago")]
        public int MetodoPagoId { get; set; }

        //DEL BONO
        [Required(ErrorMessage = "Dato de entrada requerido")]
        public string Vnominal { get; set; }
        [Required(ErrorMessage = "Dato de entrada requerido")]
        public string Vcomercial { get; set; }
        [Required(ErrorMessage = "Tasa de Interes es requerida")]
        [Display(Name = "Tasa de Interes")]
        public string TasaDeInteres { get; set; }
        [Required(ErrorMessage = "Numero de años requerido")]
        public int NAños { get; set; }
        [Required(ErrorMessage = "Dias de Año son necesarios")]
        [Display(Name = "Dias por Año")]
        public int DiasAño { get; set; }
        [Required(ErrorMessage = "Tasa de descuento anual(COK) requerida")]
        public string Cok { get; set; }
        //[Required(ErrorMessage = "Impuesto a la renta es requerido")]
        //public double ImRenta { get; set; }

        [Required(ErrorMessage = "Fecha y hora son datos requeridos")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Emision ")]
        public DateTime FechaEmision { get; set; }

        //DE LOS COSTES/GASTOS INICIALES
        public string Prima { get; set; }
        public string Estructuración { get; set; }
        public string Colocación { get; set; }
        public string Flotacion { get; set; }
        public string Cavali { get; set; }


        //public virtual ICollection<FrecuenciaPago> FrecuenciaPago { get; set; }
        //public virtual ICollection<DiasAño> DiasAño { get; set; }
        //public virtual ICollection<TasaInteres> TasaInteres { get; set; }
        //public virtual ICollection<Capitalizacion> Capitalizacion { get; set; }
        //public virtual ICollection<MetodoPago> MetodoPago { get; set; }

        public virtual FrecuenciaPago FrecuenciaPago { get; set; }
        public virtual TasaInteres TasaInteres { get; set; }
        public virtual Capitalizacion Capitalizacion { get; set; }
        public virtual MetodoPago MetodoPago { get; set; }





    }
}
