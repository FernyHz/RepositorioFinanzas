using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BonosCalculadora.Models
{
    public partial class Historial
    {
        public int HistorialId { get; set; }

        public int? ClienteId { get; set; }

        public string Observacion { get; set; }

        public virtual Cliente Cliente { get; set; }

    }
}
