using BackEnd_WebApp_PastilleroAutomatico.Models;

namespace BackEnd_WebApp_PastilleroAutomatico.Repositories
{
    public interface IPrecioRepository
    {
        Task<List<Precio>> GetListPrecio();
        Task<Precio> GetPrecio(int id);
        Task DeletePrecio(Precio precio);
        Task<Precio> AddPrecio(Precio precio);
        Task UpdatePrecio(Precio precio);
    }
}
