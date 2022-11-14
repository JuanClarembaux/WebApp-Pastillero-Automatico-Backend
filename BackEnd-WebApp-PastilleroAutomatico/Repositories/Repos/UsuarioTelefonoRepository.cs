using BackEnd_WebApp_PastilleroAutomatico.Models;
using BackEnd_WebApp_PastilleroAutomatico.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_WebApp_PastilleroAutomatico.Repositories.Repos
{
    public class UsuarioTelefonoRepository : Repository<UsuarioTelefono>, IUsuarioTelefonoRepository
    {
        private readonly ECommerce_GenericoContext _context;
        internal DbSet<UsuarioTelefono> dbSet;
        public UsuarioTelefonoRepository(ECommerce_GenericoContext context) : base(context)
        {
            _context = context;
            dbSet = _context.Set<UsuarioTelefono>();
        }
        public UsuarioTelefono FindByNumber(string telefonoUsuario, int usuarioID)
        {
            var comprobacion = dbSet.SingleOrDefault(x => x.TelefonoUsuario == telefonoUsuario && x.UsuarioId == usuarioID);
            if (comprobacion == null) return null;
            return comprobacion;
        }
        public UsuarioTelefono GetByNumber(string telefonoUsuario, int usuarioID)
        {
            return dbSet.FirstOrDefault(x => x.TelefonoUsuario == telefonoUsuario && x.UsuarioId == usuarioID);
        }
    }
}
