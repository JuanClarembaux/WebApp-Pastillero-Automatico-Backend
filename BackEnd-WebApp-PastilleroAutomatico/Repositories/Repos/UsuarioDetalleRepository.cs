using BackEnd_WebApp_PastilleroAutomatico.Models;
using BackEnd_WebApp_PastilleroAutomatico.Repositories.Interfaces;

namespace BackEnd_WebApp_PastilleroAutomatico.Repositories.Repos
{
    public class UsuarioDetalleRepository : Repository<UsuarioDetalle>, IUsuarioDetalleRepository
    {
        private readonly ECommerce_GenericoContext _context;
        public UsuarioDetalleRepository(ECommerce_GenericoContext context) : base(context)
        {
            _context = context;
        }
    }
}
