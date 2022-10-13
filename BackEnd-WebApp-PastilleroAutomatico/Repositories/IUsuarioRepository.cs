using BackEnd_WebApp_PastilleroAutomatico.Models;

namespace BackEnd_WebApp_PastilleroAutomatico.Repositories
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> GetListUsuario();
        Task<Usuario> GetUsuario(int id);
        Task<Usuario> GetUsuarioByEmail(string email);
        Task DeleteUsuario(Usuario usuario);
        Task<Usuario> AddUsuario(Usuario usuario);
        Task UpdateUsuario(Usuario usuario);
    }
}
