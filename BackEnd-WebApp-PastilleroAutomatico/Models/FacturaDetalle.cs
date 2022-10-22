using System;
using System.Collections.Generic;

namespace BackEnd_WebApp_PastilleroAutomatico.Models
{
    public partial class FacturaDetalle
    {
        public int IdFacturaDetalle { get; set; }
        public int IdFactura { get; set; }
        public int IdProducto { get; set; }
        public int CantidadProducto { get; set; }
        public decimal PrecioTotal { get; set; }
        public DateTime FechaCreacionFacturaDetalle { get; set; }
        public DateTime? FechaModificacionFacturaDetalle { get; set; }
        public DateTime? FechaEliminacionFacturaDetalle { get; set; }

        public virtual Factura IdFacturaNavigation { get; set; } = null!;
        public virtual Producto IdProductoNavigation { get; set; } = null!;
    }
}
