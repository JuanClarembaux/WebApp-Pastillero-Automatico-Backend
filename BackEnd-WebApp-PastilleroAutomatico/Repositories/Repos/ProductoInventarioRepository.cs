using BackEnd_WebApp_PastilleroAutomatico.Models;
using BackEnd_WebApp_PastilleroAutomatico.Repositories.Interfaces;

namespace BackEnd_WebApp_PastilleroAutomatico.Repositories.Repos
{
    public class ProductoInventarioRepository : Repository<ProductoInventario>, IProductoInventarioRepository
    {
        private readonly ECommerce_GenericoContext _context;
        public ProductoInventarioRepository(ECommerce_GenericoContext context) : base(context)
        {
            _context = context;
        }
    }
}
