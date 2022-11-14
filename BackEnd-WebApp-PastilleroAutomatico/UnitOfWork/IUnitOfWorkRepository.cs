using BackEnd_WebApp_PastilleroAutomatico.Repositories.Interfaces;

namespace BackEnd_WebApp_PastilleroAutomatico.UnitOfWork
{
    public interface IUnitOfWorkRepository : IDisposable
    {
        IFacturaRepository iFacturaRepository { get; }
        IProductoRepository iProductoRepository { get; }
        IProductoInventarioRepository iProductoInventarioRepository { get; }
        IProductoDescuentoRepository iProductoDescuentoRepository { get; }
        IProductoImagenRepository iProductoImagenRepository { get; }
        IUsuarioRepository iUsuarioRepository { get; }
        IUsuarioDetalleRepository iUsuarioDetalleRepository { get; }
        IUsuarioDireccionRepository iUsuarioDireccionRepository { get; }
        IUsuarioTelefonoRepository iUsuarioTelefonoRepository { get; }
        void SaveChanges();
    }
}
