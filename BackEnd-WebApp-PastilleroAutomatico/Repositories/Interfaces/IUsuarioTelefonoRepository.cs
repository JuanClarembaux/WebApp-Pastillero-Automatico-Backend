using BackEnd_WebApp_PastilleroAutomatico.Models;

namespace BackEnd_WebApp_PastilleroAutomatico.Repositories.Interfaces
{
    public interface IUsuarioTelefonoRepository : IRepository<UsuarioTelefono>
    {
        public UsuarioTelefono FindByNumber(string telefonoUsuario, int usuarioID);
        public UsuarioTelefono GetByNumber(string telefonoUsuario, int usuarioID);
    }
}
