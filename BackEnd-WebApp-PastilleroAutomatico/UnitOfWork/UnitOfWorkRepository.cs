using BackEnd_WebApp_PastilleroAutomatico.Models;
using BackEnd_WebApp_PastilleroAutomatico.Repositories.Interfaces;
using BackEnd_WebApp_PastilleroAutomatico.Repositories.Repos;

namespace BackEnd_WebApp_PastilleroAutomatico.UnitOfWork
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        private readonly ECommerce_GenericoContext _context;
        public IFacturaRepository iFacturaRepository { get; private set; }
        public IProductoRepository iProductoRepository { get; private set; }
        public IProductoInventarioRepository iProductoInventarioRepository { get; private set; }
        public IProductoDescuentoRepository iProductoDescuentoRepository { get; private set; }
        public IProductoImagenRepository iProductoImagenRepository { get; private set; }
        public IUsuarioRepository iUsuarioRepository { get; private set; }
        public IUsuarioDetalleRepository iUsuarioDetalleRepository { get; private set; }
        public IUsuarioDireccionRepository iUsuarioDireccionRepository { get; private set; }
        public IUsuarioTelefonoRepository iUsuarioTelefonoRepository { get; private set; }
        public UnitOfWorkRepository(ECommerce_GenericoContext context)
        {
            _context = context;
            iFacturaRepository = new FacturaRepository(context);
            iProductoRepository = new ProductoRepository(context);
            iProductoInventarioRepository = new ProductoInventarioRepository(context);
            iProductoDescuentoRepository = new ProductoDescuentoRepository(context);
            iProductoImagenRepository = new ProductoImagenRepository(context);
            iUsuarioRepository = new UsuarioRepository(context);
            iUsuarioDetalleRepository = new UsuarioDetalleRepository(context);
            iUsuarioDireccionRepository = new UsuarioDireccionRepository(context);
            iUsuarioTelefonoRepository = new UsuarioTelefonoRepository(context);
        }
        public void Dispose()
        {
            _context?.Dispose();
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
