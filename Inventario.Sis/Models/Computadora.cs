using System;
using System.Collections.Generic;

namespace Inventario.Sis.Models
{
    public partial class Computadora
    {
        public Computadora()
        {
            Asignacions = new HashSet<Asignacion>();
        }

        public int IdCompu { get; set; }
        public string NombreEquipo { get; set; } = null!;
        public string? Procesador { get; set; }
        public string? Ram { get; set; }
        public string? Almacenamiento { get; set; }
        public string? Placa { get; set; }
        public string? Grafica { get; set; }
        public int? Estado { get; set; }
        public string? Observacion { get; set; }

        public virtual ICollection<Asignacion> Asignacions { get; set; }
    }
}
