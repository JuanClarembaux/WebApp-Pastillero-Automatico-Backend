using BackEnd_WebApp_PastilleroAutomatico.Models;

namespace BackEnd_WebApp_PastilleroAutomatico.Repositories.Interfaces
{
    public interface IUsuarioDireccionRepository : IRepository<UsuarioDireccion>
    {
        public UsuarioDireccion FindByName(string direccionUsuario, int usuarioID);
        public UsuarioDireccion GetByName(string direccionUsuario, int usuarioID);
    }
}
