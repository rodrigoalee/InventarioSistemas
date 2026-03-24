using System;
using System.Collections.Generic;

namespace Inventario.Sis.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Asignacions = new HashSet<Asignacion>();
        }

        public int Idusuario { get; set; }
        public string? Nombre { get; set; }
        public string? Area { get; set; }
        public int? Estado { get; set; } = 1;

        public virtual ICollection<Asignacion> Asignacions { get; set; }
    }
}
