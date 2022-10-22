using BackEnd_WebApp_PastilleroAutomatico.Models;

namespace BackEnd_WebApp_PastilleroAutomatico.Repositories.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        public Usuario FindByEmail(string mail);
        public Usuario GetByEmail(string mail);
    }
}
