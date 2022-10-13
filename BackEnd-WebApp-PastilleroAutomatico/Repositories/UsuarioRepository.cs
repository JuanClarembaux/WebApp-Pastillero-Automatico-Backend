using BackEnd_WebApp_PastilleroAutomatico.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_WebApp_PastilleroAutomatico.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;
        internal DbSet<Usuario> dbSet;

        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> AddUsuario(Usuario usuario)
        {
            _context.Add(usuario);

            await _context.SaveChangesAsync();

            return usuario;
        }

        public async Task DeleteUsuario(Usuario usuario)
        {
            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Usuario>> GetListUsuario()
        {
            return await _context.Usuario.ToListAsync();
        }

        public async Task<Usuario> GetUsuario(int id)
        {
            return await _context.Usuario.FindAsync(id);
        }

        public async Task<Usuario> GetUsuarioByEmail(string email)
        {
            
            var comprobacion = dbSet.SingleOrDefault<Usuario>(x => x.Email == email);

            if (comprobacion == null) return null;

            return comprobacion;
            

            //return await _context.Usuario.FirstOrDefaultAsync(x => x.emailUsuario == email);
        }

        public async Task UpdateUsuario(Usuario usuario)
        {
            var usuarioItem = await _context.Usuario.FirstOrDefaultAsync(x => x.Id == usuario.Id);

            if (usuarioItem != null)
            {
                usuarioItem.Email = usuario.Email;
                usuarioItem.Password = usuario.Password;

                _context.Update(usuarioItem);

                await _context.SaveChangesAsync();
            }
        }
    }
}
