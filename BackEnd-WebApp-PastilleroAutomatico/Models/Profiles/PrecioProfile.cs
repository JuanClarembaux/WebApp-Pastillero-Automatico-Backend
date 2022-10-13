using AutoMapper;
using BackEnd_WebApp_PastilleroAutomatico.Models.DTO;

namespace BackEnd_WebApp_PastilleroAutomatico.Models.Profiles
{
    public class PrecioProfile : Profile
    {
        public PrecioProfile()
        {
            CreateMap<Precio, PrecioDTO>();
            CreateMap<PrecioDTO, Precio>();
        }
    }
}
