using BackEnd_WebApp_PastilleroAutomatico.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_WebApp_PastilleroAutomatico.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Producto> AddProducto(Producto producto)
        {
            producto.FechaUltimaModificacion = DateTime.Now;

            _context.Add(producto);

            await _context.SaveChangesAsync();

            return producto;
        }

        public async Task DeleteProducto(Producto producto)
        {
            _context.Producto.Remove(producto);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Producto>> GetListProducto()
        {
            return await _context.Producto.ToListAsync();
        }

        public async Task<Producto> GetProducto(int id)
        {
            return await _context.Producto.FindAsync(id);
        }

        public async Task UpdateProducto(Producto producto)
        {
            var productoItem = await _context.Producto.FirstOrDefaultAsync(x => x.Id == producto.Id);

            if (productoItem != null)
            {
                productoItem.Nombre = producto.Nombre;
                productoItem.Marca = producto.Marca;
                productoItem.Descripcion = producto.Descripcion;
                productoItem.Stock = producto.Stock;
                productoItem.FechaUltimaModificacion = DateTime.Now;

                _context.Update(productoItem);

                await _context.SaveChangesAsync();
            }            
        }
    }
}
