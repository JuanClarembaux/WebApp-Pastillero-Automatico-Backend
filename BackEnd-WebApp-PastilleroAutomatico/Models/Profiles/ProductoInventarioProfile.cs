using AutoMapper;
using BackEnd_WebApp_PastilleroAutomatico.Models.DTO;

namespace BackEnd_WebApp_PastilleroAutomatico.Models.Profiles
{
    public class ProductoInventarioProfile : Profile
    {
        public ProductoInventarioProfile()
        {
            CreateMap<ProductoInventario, ProductoInventarioDTO>();
            CreateMap<ProductoInventarioDTO, ProductoInventario>();
        }
    }
}
