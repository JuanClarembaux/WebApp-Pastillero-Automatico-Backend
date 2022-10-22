using System;
using System.Collections.Generic;

namespace BackEnd_WebApp_PastilleroAutomatico.Models
{
    public partial class ProductoInventario
    {
        public int IdProductoInventario { get; set; }
        public int ProductoId { get; set; }
        public string NombreProductoInventario { get; set; } = null!;
        public int? CantidadProductoInventario { get; set; }
        public bool ActivoProductoInventario { get; set; }
        public DateTime FechaCreacionProductoInventario { get; set; }
        public DateTime? FechaModificacionProductoInventario { get; set; }
        public DateTime? FechaEliminacionProductoInventario { get; set; }

        public virtual Producto Producto { get; set; } = null!;
    }
}
