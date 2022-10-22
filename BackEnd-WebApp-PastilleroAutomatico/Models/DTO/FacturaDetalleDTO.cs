namespace BackEnd_WebApp_PastilleroAutomatico.Models.DTO
{
    public class FacturaDetalleDTO
    {
        public int IdFacturaDetalle { get; set; }
        public int IdFactura { get; set; }
        public int IdProducto { get; set; }
        public int CantidadProducto { get; set; }
        public decimal PrecioTotal { get; set; }
        public DateTime FechaCreacionFacturaDetalle { get; set; }
        public DateTime? FechaModificacionFacturaDetalle { get; set; }
        public DateTime? FechaEliminacionFacturaDetalle { get; set; }
    }
}
