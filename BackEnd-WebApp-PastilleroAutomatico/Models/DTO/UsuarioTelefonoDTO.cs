namespace BackEnd_WebApp_PastilleroAutomatico.Models.DTO
{
    public class UsuarioTelefonoDTO
    {
        public int IdUsuarioTelefono { get; set; }
        public int UsuarioId { get; set; }
        public string TelefonoUsuario { get; set; } = null!;
        public bool ActivoUsuarioTelefono { get; set; }
        public DateTime FechaCreacionUsuarioTelefono { get; set; }
        public DateTime? FechaModificacionUsuarioTelefono { get; set; }
        public DateTime? FechaEliminacionUsuarioTelefono { get; set; }
    }
}
