using BackEnd_WebApp_PastilleroAutomatico.Models;
using BackEnd_WebApp_PastilleroAutomatico.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BackEnd_WebApp_PastilleroAutomatico.Repositories.Repos
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        private readonly ECommerce_GenericoContext _context;
        internal DbSet<Usuario> dbSet;
        public UsuarioRepository(ECommerce_GenericoContext context) : base(context)
        {
            _context = context;
            dbSet = _context.Set<Usuario>();
        }
        public Usuario FindByEmail(string mail)
        {
            var comprobacion = dbSet.SingleOrDefault<Usuario>(x => x.MailUsuario == mail);
            if (comprobacion == null) return null;
            return comprobacion;
        }
        public Usuario GetByEmail(string mail)
        {
            return dbSet.FirstOrDefault<Usuario>(x => x.MailUsuario == mail);
        }
    }
}
