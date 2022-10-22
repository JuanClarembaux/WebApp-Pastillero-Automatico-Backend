using AutoMapper;
using BackEnd_WebApp_PastilleroAutomatico.Models.DTO;

namespace BackEnd_WebApp_PastilleroAutomatico.Models.Profiles
{
    public class ProductoDescuentoProfile : Profile
    {
        public ProductoDescuentoProfile()
        {
            CreateMap<ProductoDescuento, ProductoDescuentoDTO>();
            CreateMap<ProductoDescuentoDTO, ProductoDescuento>();
        }
    }
}
