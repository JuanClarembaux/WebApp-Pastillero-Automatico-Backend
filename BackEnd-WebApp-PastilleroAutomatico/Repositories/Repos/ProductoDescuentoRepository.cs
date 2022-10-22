using BackEnd_WebApp_PastilleroAutomatico.Models;
using BackEnd_WebApp_PastilleroAutomatico.Repositories.Interfaces;

namespace BackEnd_WebApp_PastilleroAutomatico.Repositories.Repos
{
    public class ProductoDescuentoRepository : Repository<ProductoDescuento>, IProductoDescuentoRepository
    {
        private readonly ECommerce_GenericoContext _context;
        public ProductoDescuentoRepository(ECommerce_GenericoContext context) : base(context)
        {
            _context = context;
        }
    }
}
