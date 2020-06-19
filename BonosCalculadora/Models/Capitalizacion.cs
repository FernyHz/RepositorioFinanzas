using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BonosCalculadora.Models
{
    public partial class Capitalizacion
    {
        public int CapitalizacionId { get; set; }
        [Required(ErrorMessage = "La capitalizacion es requerida")]
        [DataType(DataType.Text)]
        public string TipoCapitalizacion { get; set; }
        public virtual ICollection<Calculadora> Calculadora { get; set; }

    }
}
