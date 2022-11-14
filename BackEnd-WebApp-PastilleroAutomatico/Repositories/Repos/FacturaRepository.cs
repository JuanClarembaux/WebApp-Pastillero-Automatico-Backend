using BackEnd_WebApp_PastilleroAutomatico.Models;
using BackEnd_WebApp_PastilleroAutomatico.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_WebApp_PastilleroAutomatico.Repositories.Repos
{
    public class FacturaRepository : Repository<Factura>, IFacturaRepository
    {
        private readonly ECommerce_GenericoContext _context;
        internal DbSet<Factura> dbSet;
        public FacturaRepository(ECommerce_GenericoContext context) : base(context)
        {
            _context = context;
            dbSet = _context.Set<Factura>();
        }
        public Factura FindByNumber(string numeroFactura)
        {
            var comprobacion = dbSet.SingleOrDefault(x => x.NumeroFactura == numeroFactura);
            if (comprobacion == null) return null;
            return comprobacion;
        }
        public Factura GetByNumber(string numeroFactura)
        {
            return dbSet.FirstOrDefault(x => x.NumeroFactura == numeroFactura
);
        }
    }
}
