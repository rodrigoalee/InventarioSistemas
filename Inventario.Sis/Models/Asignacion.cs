using System;
using System.Collections.Generic;

namespace Inventario.Sis.Models
{
    public partial class Asignacion
    {
        public int IdAsignacion { get; set; }
        public int Idusuario { get; set; }
        public int? IdCompu { get; set; }
        public int? IdMonitor { get; set; }
        public int? IdImpresora { get; set; }
        public int? Idperiferico { get; set; }
        public int? IdUps { get; set; }
        public string? Observacion { get; set; }

        public virtual Computadora? IdCompuNavigation { get; set; }
        public virtual Impresora? IdImpresoraNavigation { get; set; }
        public virtual Monitore? IdMonitorNavigation { get; set; }
        public virtual Up? IdUpsNavigation { get; set; }
        public virtual Periferico? IdperifericoNavigation { get; set; }
        public virtual Usuario IdusuarioNavigation { get; set; } = null!;
    }
}
