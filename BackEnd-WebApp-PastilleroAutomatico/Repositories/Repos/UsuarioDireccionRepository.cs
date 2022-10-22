using BackEnd_WebApp_PastilleroAutomatico.Models;
using BackEnd_WebApp_PastilleroAutomatico.Repositories.Interfaces;

namespace BackEnd_WebApp_PastilleroAutomatico.Repositories.Repos
{
    public class UsuarioDireccionRepository : Repository<UsuarioDireccion>, IUsuarioDireccionRepository
    {
        private readonly ECommerce_GenericoContext _context;
        public UsuarioDireccionRepository(ECommerce_GenericoContext context) : base(context)
        {
            _context = context;
        }
    }
}
