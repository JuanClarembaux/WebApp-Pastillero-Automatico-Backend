using Microsoft.EntityFrameworkCore;

namespace BackEnd_WebApp_PastilleroAutomatico.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Persona> Persona { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Precio> Precio { get; set; }
    }
}
