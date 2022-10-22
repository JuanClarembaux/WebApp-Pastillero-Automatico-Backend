namespace BackEnd_WebApp_PastilleroAutomatico.Models.DTO
{
    public class UsuarioDetalleDTO
    {
        public int IdUsuarioDetalle { get; set; }
        public int UsuarioId { get; set; }
        public string? NombreUsuario { get; set; }
        public string? ApellidoUsuario { get; set; }
        public DateTime? FechaNacimientoUsuario { get; set; }
        public DateTime FechaCreacionUsuarioDetalle { get; set; }
        public DateTime? FechaModificacionUsuarioDetalle { get; set; }
        public DateTime? FechaEliminacionUsuarioDetalle { get; set; }
    }
}
