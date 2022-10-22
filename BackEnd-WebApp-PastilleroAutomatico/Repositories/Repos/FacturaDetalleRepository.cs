using BackEnd_WebApp_PastilleroAutomatico.Models;
using BackEnd_WebApp_PastilleroAutomatico.Repositories.Interfaces;

namespace BackEnd_WebApp_PastilleroAutomatico.Repositories.Repos
{
    public class FacturaDetalleRepository : Repository<FacturaDetalle>, IFacturaDetalleRepository
    {
        private readonly ECommerce_GenericoContext _context;
        public FacturaDetalleRepository(ECommerce_GenericoContext context) : base(context)
        {
            _context = context;
        }
    }
}
