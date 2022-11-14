using BackEnd_WebApp_PastilleroAutomatico.Models;
using BackEnd_WebApp_PastilleroAutomatico.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_WebApp_PastilleroAutomatico.Repositories.Repos
{
    public class ProductoDescuentoRepository : Repository<ProductoDescuento>, IProductoDescuentoRepository
    {
        private readonly ECommerce_GenericoContext _context;
        internal DbSet<ProductoDescuento> dbSet;
        public ProductoDescuentoRepository(ECommerce_GenericoContext context) : base(context)
        {
            _context = context;
            dbSet = _context.Set<ProductoDescuento>();
        }
        public ProductoDescuento FindByName(string nombreProductoDescuento, int productoID)
        {
            var comprobacion = dbSet.SingleOrDefault(x => x.NombreProductoDescuento == nombreProductoDescuento && x.ProductoId == productoID);
            if (comprobacion == null) return null;
            return comprobacion;
        }
        public ProductoDescuento GetByName(string nombreProductoDescuento, int productoID)
        {
            return dbSet.FirstOrDefault(x => x.NombreProductoDescuento == nombreProductoDescuento && x.ProductoId == productoID);
        }
    }
}
