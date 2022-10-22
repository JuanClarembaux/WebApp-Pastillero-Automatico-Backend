namespace BackEnd_WebApp_PastilleroAutomatico.Models.DTO
{
    public class ProductoDescuentoDTO
    {
        public int IdProductoDescuento { get; set; }
        public int ProductoId { get; set; }
        public string NombreProductoDescuento { get; set; } = null!;
        public decimal PorcentajeProductoDescuento { get; set; }
        public bool ActivoProductoDescuento { get; set; }
        public DateTime FechaCreacionProductoDescuento { get; set; }
        public DateTime? FechaModificacionProductoDescuento { get; set; }
        public DateTime? FechaEliminacionProductoDescuento { get; set; }
    }
}
