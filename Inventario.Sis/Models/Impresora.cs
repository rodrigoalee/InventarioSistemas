using System;
using System.Collections.Generic;

namespace Inventario.Sis.Models
{
    public partial class Impresora
    {
        public Impresora()
        {
            Asignacions = new HashSet<Asignacion>();
        }

        public int IdImpresora { get; set; }
        public string Marca { get; set; } = null!;
        public string? Serie { get; set; }
        public string? Tipotinta { get; set; }
        public string? Observacion { get; set; }
        public int? Estado { get; set; } = 1;

        public virtual ICollection<Asignacion> Asignacions { get; set; }
    }
}
