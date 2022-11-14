namespace BackEnd_WebApp_PastilleroAutomatico.Models.DTO
{
    public class UsuarioRegisterDTO
    {
        public string MailUsuario { get; set; } = null!;
        public string PasswordUsuario { get; set; } = null!;        
        public string? NombreUsuario { get; set; }
        public string? ApellidoUsuario { get; set; }
        public DateTime? FechaNacimientoUsuario { get; set; }      
    }
}
