using System;
using System.Collections.Generic;

namespace Inventario.Sis.Models
{
    public partial class Up
    {
        public Up()
        {
            Asignacions = new HashSet<Asignacion>();
        }

        public int IdUps { get; set; }
        public string? Marca { get; set; }
        public string? Serie { get; set; }
        public string? Observacion { get; set; }
        public int? Estado { get; set; }

        public virtual ICollection<Asignacion> Asignacions { get; set; }
    }
}
