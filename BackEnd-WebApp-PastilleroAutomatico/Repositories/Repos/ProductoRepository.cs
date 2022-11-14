using BackEnd_WebApp_PastilleroAutomatico.Models;
using BackEnd_WebApp_PastilleroAutomatico.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BackEnd_WebApp_PastilleroAutomatico.Repositories.Repos
{
    public class ProductoRepository : Repository<Producto>, IProductoRepository
    {
        private readonly ECommerce_GenericoContext _context;
        internal DbSet<Producto> dbSet;
        public ProductoRepository(ECommerce_GenericoContext context) : base(context)
        {
            _context = context;
            dbSet = _context.Set <Producto> ();
        }
        public Producto FindByName(string nombreProducto)
        {
            var comprobacion = dbSet.SingleOrDefault(x => x.NombreProducto == nombreProducto);
            if (comprobacion == null) return null;
            return comprobacion;
        }
        public Producto GetByName(string nombreProducto)
        {
            return dbSet.FirstOrDefault(x => x.NombreProducto == nombreProducto);
        }
    }
}
