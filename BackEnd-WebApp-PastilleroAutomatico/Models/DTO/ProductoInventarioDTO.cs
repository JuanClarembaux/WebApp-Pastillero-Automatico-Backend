namespace BackEnd_WebApp_PastilleroAutomatico.Models.DTO
{
    public class ProductoInventarioDTO
    {
        public int IdProductoInventario { get; set; }
        public int ProductoId { get; set; }
        public string NombreProductoInventario { get; set; } = null!;
        public int? CantidadProductoInventario { get; set; }
        public bool ActivoProductoInventario { get; set; }
        public DateTime FechaCreacionProductoInventario { get; set; }
        public DateTime? FechaModificacionProductoInventario { get; set; }
        public DateTime? FechaEliminacionProductoInventario { get; set; }

        public ProductoInventarioDTO(string NombreProductoInventario, int? CantidadProductoInventario)
        {
            this.NombreProductoInventario = NombreProductoInventario;
            this.CantidadProductoInventario = CantidadProductoInventario;
        }
    }
}
