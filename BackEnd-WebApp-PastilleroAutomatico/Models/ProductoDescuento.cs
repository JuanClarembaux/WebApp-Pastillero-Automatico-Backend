using System;
using System.Collections.Generic;

namespace BackEnd_WebApp_PastilleroAutomatico.Models
{
    public partial class ProductoDescuento
    {
        public int IdProductoDescuento { get; set; }
        public int ProductoId { get; set; }
        public string NombreProductoDescuento { get; set; } = null!;
        public decimal PorcentajeProductoDescuento { get; set; }
        public bool ActivoProductoDescuento { get; set; }
        public DateTime FechaCreacionProductoDescuento { get; set; }
        public DateTime? FechaModificacionProductoDescuento { get; set; }
        public DateTime? FechaEliminacionProductoDescuento { get; set; }

        public virtual Producto Producto { get; set; } = null!;
    }
}
