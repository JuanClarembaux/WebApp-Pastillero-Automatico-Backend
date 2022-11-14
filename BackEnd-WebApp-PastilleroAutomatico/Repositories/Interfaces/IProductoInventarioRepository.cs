using BackEnd_WebApp_PastilleroAutomatico.Models;

namespace BackEnd_WebApp_PastilleroAutomatico.Repositories.Interfaces
{
    public interface IProductoInventarioRepository : IRepository<ProductoInventario>
    {
        public ProductoInventario FindByName(string nombreProductoInventario, int productoID);
        public ProductoInventario GetByName(string nombreProductoInventario, int productoID);
    }
}
