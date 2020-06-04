using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BonosCalculadora.Models
{
    public partial class Cliente
    {
        public int ClienteId { get; set; }
        public string Usuario { get; set; }

        [Required(ErrorMessage = "El Nombre es requerido")]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Los Apellidos son requeridos")]
        [DataType(DataType.Text)]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "DNI es requerido")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "DNI requiere 8 caracteres")]
        public string Dni { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Correo { get; set; }

        public virtual ICollection<Historial> Historial { get; set; }
    }
}
