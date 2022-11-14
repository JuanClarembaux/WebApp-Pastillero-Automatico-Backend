namespace BackEnd_WebApp_PastilleroAutomatico.Models.DTO
{
    public class ProductoEInventarioDTO
    {
        public string NombreProducto { get; set; } = null!;
        public string? MarcaProducto { get; set; }
        public string? DescripcionProducto { get; set; }
        public string? CategoriaProducto { get; set; }
        public decimal? PrecioProducto { get; set; }
        public string? SkuProducto { get; set; }
        public string NombreProductoInventario { get; set; } = null!;
        public int? CantidadProductoInventario { get; set; }
    }
}
