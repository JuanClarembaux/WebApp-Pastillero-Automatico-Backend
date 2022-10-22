using System;
using System.Collections.Generic;

namespace BackEnd_WebApp_PastilleroAutomatico.Models
{
    public partial class ProductoImagen
    {
        public int IdProductoImagen { get; set; }
        public int ProductoId { get; set; }
        public string NombreProductoImagen { get; set; } = null!;
        public byte[] ArchivoProductoImagen { get; set; } = null!;

        public virtual Producto Producto { get; set; } = null!;
    }
}
