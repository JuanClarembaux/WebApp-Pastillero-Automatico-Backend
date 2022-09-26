using Microsoft.EntityFrameworkCore;

namespace BackEnd_WebApp_PastilleroAutomatico.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Producto> Producto { get; set; }
    }
}
