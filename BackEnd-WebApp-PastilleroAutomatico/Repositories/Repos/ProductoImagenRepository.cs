using BackEnd_WebApp_PastilleroAutomatico.Models;
using BackEnd_WebApp_PastilleroAutomatico.Repositories.Interfaces;

namespace BackEnd_WebApp_PastilleroAutomatico.Repositories.Repos
{
    public class ProductoImagenRepository : Repository<ProductoImagen>, IProductoImagenRepository
    {
        private readonly ECommerce_GenericoContext _context;
        public ProductoImagenRepository(ECommerce_GenericoContext context) : base(context)
        {
            _context = context;
        }
    }
}
