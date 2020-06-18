using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BonosCalculadora.Models
{
    public partial class TasaInteres
    {
        public int TasaInteresId { get; set; }

       // [Required(ErrorMessage = "Introduzca Tasa")]
        public double Tasa { get; set; }

     //   [Required(ErrorMessage = "Tipo de Tasa es Requerido")]
     //   [DataType(DataType.Text)]
        public string Tipotasa { get; set; }
        public virtual ICollection<Calculadora> Calculadora { get; set; }
    }
}
