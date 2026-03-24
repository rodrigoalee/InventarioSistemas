using System;
using System.Collections.Generic;

namespace Inventario.Sis.Models
{
    public partial class Monitore
    {
        public Monitore()
        {
            Asignacions = new HashSet<Asignacion>();
        }

        public int IdMonitor { get; set; }
        public string Marca { get; set; } = null!;
        public string? Serie { get; set; }
        public string? Observacion { get; set; }
        public int? Estado { get; set; }

        public virtual ICollection<Asignacion> Asignacions { get; set; }
    }
}
