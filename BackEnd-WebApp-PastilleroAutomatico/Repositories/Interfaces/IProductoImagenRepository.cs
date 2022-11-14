using BackEnd_WebApp_PastilleroAutomatico.Models;

namespace BackEnd_WebApp_PastilleroAutomatico.Repositories.Interfaces
{
    public interface IProductoImagenRepository : IRepository<ProductoImagen>
    {
        public ProductoImagen FindByName(string nombreProductoImagen);
        public ProductoImagen GetByName(string nombreProductoImagen);
    }
}
