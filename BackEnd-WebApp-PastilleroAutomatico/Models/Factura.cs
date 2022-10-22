using System;
using System.Collections.Generic;

namespace BackEnd_WebApp_PastilleroAutomatico.Models
{
    public partial class Factura
    {
        public Factura()
        {
            FacturaDetalles = new HashSet<FacturaDetalle>();
        }

        public int IdFactura { get; set; }
        public int UsuarioId { get; set; }
        public string NumeroFactura { get; set; } = null!;
        public bool ActivoFactura { get; set; }
        public DateTime FechaCreacionFactura { get; set; }
        public DateTime? FechaModificacionFactura { get; set; }
        public DateTime? FechaEliminacionFactura { get; set; }

        public virtual Usuario Usuario { get; set; } = null!;
        public virtual ICollection<FacturaDetalle> FacturaDetalles { get; set; }
    }
}
