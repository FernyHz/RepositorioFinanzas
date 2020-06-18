using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BonosCalculadora.Models
{
    public partial class DiasAño
    {
        public int DiasAñoId { get; set; }
        public int? CalculadoraId { get; set; }

        [Required(ErrorMessage = "Los dias son requeridos")]
        public int Dias { get;set; }

        public virtual ICollection<Calculadora> Calculadora { get; set; }

    }
}
