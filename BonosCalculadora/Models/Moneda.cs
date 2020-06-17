using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BonosCalculadora.Models
{
    public partial class Moneda
    {
        public int MonedaId { get; set; }

        [Required(ErrorMessage = "El tipo de moneda es requerida")]
        [DataType(DataType.Text)]
        public string TipoMoneda { get; set; }
    }
}
