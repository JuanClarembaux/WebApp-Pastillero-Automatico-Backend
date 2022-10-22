namespace BackEnd_WebApp_PastilleroAutomatico.Models.DTO
{
    public class UsuarioDireccionDTO
    {
        public int IdUsuarioDireccion { get; set; }
        public int UsuarioId { get; set; }
        public string DireccionUsuario { get; set; } = null!;
        public string Ciudad { get; set; } = null!;
        public string Provincia { get; set; } = null!;
        public string Pais { get; set; } = null!;
        public bool ActivoUsuarioDireccion { get; set; }
        public DateTime FechaCreacionUsuarioDireccion { get; set; }
        public DateTime? FechaModificacionUsuarioDireccion { get; set; }
        public DateTime? FechaEliminacionUsuarioDireccion { get; set; }
    }
}
