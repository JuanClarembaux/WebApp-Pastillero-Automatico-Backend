using BackEnd_WebApp_PastilleroAutomatico.Models;

namespace BackEnd_WebApp_PastilleroAutomatico.Repositories.Interfaces
{
    public interface IFacturaRepository : IRepository<Factura>
    {
        public Factura FindByNumber(string numeroFactura);
        public Factura GetByNumber(string numeroFactura);
    }
}
