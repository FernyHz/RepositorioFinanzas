using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BonosCalculadora.Models
{
    public partial class MetodoPago
    {
        public int MetodoPagoId { get; set; }

        [Required(ErrorMessage = "Nombre es requerido")]
        public string TipoMetodo { get; set; }

        public virtual ICollection<Calculadora> Calculadora { get; set; }
    }
}
