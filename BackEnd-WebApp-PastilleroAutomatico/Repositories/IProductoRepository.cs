using BackEnd_WebApp_PastilleroAutomatico.Models;

namespace BackEnd_WebApp_PastilleroAutomatico.Repositories
{
    public interface IProductoRepository
    {
        Task<List<Producto>> GetListProducto();
        Task<Producto> GetProducto(int id);
        Task DeleteProducto(Producto producto);
        Task<Producto> AddProducto(Producto producto);
        Task UpdateProducto(Producto producto);
    }
}
