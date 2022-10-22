namespace BackEnd_WebApp_PastilleroAutomatico.Models.DTO
{
    public class UsuarioDTO
    {
        public int IdUsuario { get; set; }
        public string MailUsuario { get; set; } = null!;
        public string PasswordUsuario { get; set; } = null!;
        public string RolUsuario { get; set; } = null!;
        public bool ActivoUsuario { get; set; }
        public DateTime FechaCreacionUsuario { get; set; }
        public DateTime? FechaModificacionUsuario { get; set; }
        public DateTime? FechaEliminacionUsuario { get; set; }
    }
}
