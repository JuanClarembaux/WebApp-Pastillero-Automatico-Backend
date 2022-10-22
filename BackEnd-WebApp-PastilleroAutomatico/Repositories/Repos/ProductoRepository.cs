using BackEnd_WebApp_PastilleroAutomatico.Models;
using BackEnd_WebApp_PastilleroAutomatico.Repositories.Interfaces;

namespace BackEnd_WebApp_PastilleroAutomatico.Repositories.Repos
{
    public class ProductoRepository : Repository<Producto>, IProductoRepository
    {
        private readonly ECommerce_GenericoContext _context;
        public ProductoRepository(ECommerce_GenericoContext context) : base(context)
        {
            _context = context;
        }
    }
}
