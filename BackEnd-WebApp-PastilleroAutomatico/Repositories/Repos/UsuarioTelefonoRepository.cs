using BackEnd_WebApp_PastilleroAutomatico.Models;
using BackEnd_WebApp_PastilleroAutomatico.Repositories.Interfaces;

namespace BackEnd_WebApp_PastilleroAutomatico.Repositories.Repos
{
    public class UsuarioTelefonoRepository : Repository<UsuarioTelefono>, IUsuarioTelefonoRepository
    {
        private readonly ECommerce_GenericoContext _context;
        public UsuarioTelefonoRepository(ECommerce_GenericoContext context) : base(context)
        {
            _context = context;
        }
    }
}
