using BackEnd_WebApp_PastilleroAutomatico.Models;
using BackEnd_WebApp_PastilleroAutomatico.Repositories.Interfaces;

namespace BackEnd_WebApp_PastilleroAutomatico.Repositories.Repos
{
    public class FacturaRepository : Repository<Factura>, IFacturaRepository
    {
        private readonly ECommerce_GenericoContext _context;
        public FacturaRepository(ECommerce_GenericoContext context) : base(context)
        {
            _context = context;
        }
    }
}
