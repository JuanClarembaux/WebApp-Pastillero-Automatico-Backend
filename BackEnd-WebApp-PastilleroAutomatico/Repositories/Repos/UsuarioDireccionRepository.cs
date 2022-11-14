using BackEnd_WebApp_PastilleroAutomatico.Models;
using BackEnd_WebApp_PastilleroAutomatico.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_WebApp_PastilleroAutomatico.Repositories.Repos
{
    public class UsuarioDireccionRepository : Repository<UsuarioDireccion>, IUsuarioDireccionRepository
    {
        private readonly ECommerce_GenericoContext _context;
        internal DbSet<UsuarioDireccion> dbSet;
        public UsuarioDireccionRepository(ECommerce_GenericoContext context) : base(context)
        {
            _context = context;
            dbSet = _context.Set<UsuarioDireccion>();
        }
        public UsuarioDireccion FindByName(string direccionUsuario, int usuarioID)
        {
            var comprobacion = dbSet.SingleOrDefault(x => x.DireccionUsuario == direccionUsuario && x.UsuarioId == usuarioID);
            if (comprobacion == null) return null;
            return comprobacion;
        }
        public UsuarioDireccion GetByName(string direccionUsuario, int usuarioID)
        {
            return dbSet.FirstOrDefault(x => x.DireccionUsuario == direccionUsuario && x.UsuarioId == usuarioID);
        }
    }
}
