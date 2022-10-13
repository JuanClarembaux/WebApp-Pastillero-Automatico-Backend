namespace BackEnd_WebApp_PastilleroAutomatico.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public int personaID { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; }
        public string RolUsuario { get; set; }

        
        /*public string RefreshToken { get; set; } = string.Empty;
        public DateTime TokenCreated { get; set; }
        public DateTime TokenExpires { get; set; }*/
    }
}
