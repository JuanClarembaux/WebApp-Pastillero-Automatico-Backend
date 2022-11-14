using BackEnd_WebApp_PastilleroAutomatico.Models;
using BackEnd_WebApp_PastilleroAutomatico.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_WebApp_PastilleroAutomatico.Repositories.Repos
{
    public class ProductoInventarioRepository : Repository<ProductoInventario>, IProductoInventarioRepository
    {
        private readonly ECommerce_GenericoContext _context;
        internal DbSet<ProductoInventario> dbSet;
        public ProductoInventarioRepository(ECommerce_GenericoContext context) : base(context)
        {
            _context = context;
            dbSet = _context.Set<ProductoInventario>();
        }
        public ProductoInventario FindByName(string nombreProductoInventario, int productoID)
        {
            var comprobacion = dbSet.SingleOrDefault(x => x.NombreProductoInventario == nombreProductoInventario && x.ProductoId == productoID);
            if (comprobacion == null) return null;
            return comprobacion;
        }
        public ProductoInventario GetByName(string nombreProductoInventario, int productoID)
        {
            return dbSet.FirstOrDefault(x => x.NombreProductoInventario == nombreProductoInventario && x.ProductoId == productoID);
        }
    }
}
