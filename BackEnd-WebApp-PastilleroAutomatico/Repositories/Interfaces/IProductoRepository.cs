using BackEnd_WebApp_PastilleroAutomatico.Models;

namespace BackEnd_WebApp_PastilleroAutomatico.Repositories.Interfaces
{
    public interface IProductoRepository : IRepository<Producto>
    {
        public Producto FindByName(string nombreProducto);
        public Producto GetByName(string nombreProducto);
    }
}
