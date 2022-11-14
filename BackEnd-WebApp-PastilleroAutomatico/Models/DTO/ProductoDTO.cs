namespace BackEnd_WebApp_PastilleroAutomatico.Models.DTO
{
    public class ProductoDTO
    {
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

        public ProductoDTO(string? NombreProducto, string? MarcaProducto, string? DescripcionProducto, string? CategoriaProducto, decimal? PrecioProducto, string? SkuProducto)
        {
            this.NombreProducto = NombreProducto;
            this.MarcaProducto = MarcaProducto;
            this.DescripcionProducto = DescripcionProducto;
            this.CategoriaProducto = CategoriaProducto;
            this.PrecioProducto = PrecioProducto;
            this.SkuProducto = SkuProducto;
        }
    }
}
