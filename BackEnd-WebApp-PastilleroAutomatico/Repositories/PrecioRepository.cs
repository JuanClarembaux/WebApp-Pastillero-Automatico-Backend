using BackEnd_WebApp_PastilleroAutomatico.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_WebApp_PastilleroAutomatico.Repositories
{
    public class PrecioRepository : IPrecioRepository
    {
        private readonly ApplicationDbContext _context;

        public PrecioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Precio> AddPrecio(Precio precio)
        {

            _context.Add(precio);

            await _context.SaveChangesAsync();

            return precio;
        }

        public async Task DeletePrecio(Precio precio)
        {
            _context.Precio.Remove(precio);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Precio>> GetListPrecio()
        {
            return await _context.Precio.ToListAsync();
        }

        public async Task<Precio> GetPrecio(int id)
        {
            return await _context.Precio.FindAsync(id);
        }

        public async Task UpdatePrecio(Precio precio)
        {
            var precioItem = await _context.Precio.FirstOrDefaultAsync(x => x.Id == precio.Id);

            if (precioItem != null)
            {
                precioItem.precioBaseProducto = precio.precioBaseProducto;
                precioItem.costoImpuestos = precio.costoImpuestos;
                precioItem.precioTotalProducto = precio.precioTotalProducto;

                _context.Update(precioItem);

                await _context.SaveChangesAsync();
            }
        }
    }
}
