using System;
using System.Collections.Generic;

namespace Inventario.Sis.Models
{
    public partial class Insumo
    {
        public int IdInsumo { get; set; }
        public string NombreInsumo { get; set; } = null!;
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
        public string? UnidadMedida { get; set; }
        public int? Estado { get; set; }
        public string? Observacion { get; set; }
        public DateTime? Ultimacarga { get; set; }
    }
}
