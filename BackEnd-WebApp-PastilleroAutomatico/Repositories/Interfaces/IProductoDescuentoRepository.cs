using BackEnd_WebApp_PastilleroAutomatico.Models;

namespace BackEnd_WebApp_PastilleroAutomatico.Repositories.Interfaces
{
   public interface IProductoDescuentoRepository : IRepository<ProductoDescuento>
    {
        public ProductoDescuento FindByName(string nombreProductoDescuento, int productoID);
        public ProductoDescuento GetByName(string nombreProductoDescuento, int productoID);
    }
}
