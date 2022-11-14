using BackEnd_WebApp_PastilleroAutomatico.Models;

namespace BackEnd_WebApp_PastilleroAutomatico.Repositories.Interfaces
{
    public interface IUsuarioDetalleRepository : IRepository<UsuarioDetalle>
    {
        public UsuarioDetalle FindByUserID(int usuarioID);
    }
}
