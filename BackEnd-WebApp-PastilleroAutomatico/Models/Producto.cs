using System;
using System.Collections.Generic;

namespace BackEnd_WebApp_PastilleroAutomatico.Models
{
    public partial class Producto
    {
        public Producto()
        {
            ProductoDescuentos = new HashSet<ProductoDescuento>();
            ProductoImagens = new HashSet<ProductoImagen>();
            ProductoInventarios = new HashSet<ProductoInventario>();
        }

        public int IdProducto { get; set; }
        public string NombreProducto { get; set; } = null!;
        public string? MarcaProducto { get; set; }
        public string? DescripcionProducto { get; set; }
        public string? CategoriaProducto { get; set; }
        public decimal? PrecioProducto { get; set; }
        public string? SkuProducto { get; set; }
        public bool ActivoProducto { get; set; }
        public DateTime FechaCreacionProducto { get; set; }
        public DateTime? FechaModificacionProducto { get; set; }
        public DateTime? FechaEliminacionProducto { get; set; }

        public virtual ICollection<ProductoDescuento> ProductoDescuentos { get; set; }
        public virtual ICollection<ProductoImagen> ProductoImagens { get; set; }
        public virtual ICollection<ProductoInventario> ProductoInventarios { get; set; }
    }
}
