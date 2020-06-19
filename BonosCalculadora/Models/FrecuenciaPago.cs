using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BonosCalculadora.Models
{
    public partial class FrecuenciaPago
    {
        public int FrecuenciaPagoId { get; set; }
        [Required(ErrorMessage = "Tipode de frecuencia es requerido")]
        [DataType(DataType.Text)]
        public string Tipofrecuencia { get; set; }

       // [Required(ErrorMessage = "Dias de la frecuencia necesarios")]
       // public int Diasfrecuencia { get; set; }

        public virtual ICollection<Calculadora> Calculadora { get; set; }
    }
}
