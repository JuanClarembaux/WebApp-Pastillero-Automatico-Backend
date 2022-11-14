using BackEnd_WebApp_PastilleroAutomatico.Models;
using BackEnd_WebApp_PastilleroAutomatico.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_WebApp_PastilleroAutomatico.Repositories.Repos
{
    public class ProductoImagenRepository : Repository<ProductoImagen>, IProductoImagenRepository
    {
        private readonly ECommerce_GenericoContext _context;
        internal DbSet<ProductoImagen> dbSet;
        public ProductoImagenRepository(ECommerce_GenericoContext context) : base(context)
        {
            _context = context;
            dbSet = _context.Set<ProductoImagen>();
        }
        public ProductoImagen FindByName(string nombreProductoImagen)
        {
            var comprobacion = dbSet.SingleOrDefault(x => x.NombreProductoImagen == nombreProductoImagen);
            if (comprobacion == null) return null;
            return comprobacion;
        }
        public ProductoImagen GetByName(string nombreProductoImagen)
        {
            return dbSet.FirstOrDefault(x => x.NombreProductoImagen == nombreProductoImagen);
        }
    }
}
