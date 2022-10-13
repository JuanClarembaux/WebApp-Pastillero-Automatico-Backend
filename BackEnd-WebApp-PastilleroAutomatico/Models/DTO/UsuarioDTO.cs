namespace BackEnd_WebApp_PastilleroAutomatico.Models.DTO
{
    public class UsuarioDTO
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string RolUsuario { get; set; } = "usuario";
    }
}
