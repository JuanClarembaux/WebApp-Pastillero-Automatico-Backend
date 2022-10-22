using AutoMapper;
using BackEnd_WebApp_PastilleroAutomatico.Models.DTO;

namespace BackEnd_WebApp_PastilleroAutomatico.Models.Profiles
{
    public class ProductoImagenProfile : Profile
    {
        public ProductoImagenProfile()
        {
            CreateMap<ProductoImagen, ProductoImagenDTO>();
            CreateMap<ProductoImagenDTO, ProductoImagen>();
        }
    }
}
