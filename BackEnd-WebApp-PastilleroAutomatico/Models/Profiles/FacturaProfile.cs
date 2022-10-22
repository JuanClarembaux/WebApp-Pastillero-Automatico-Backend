using AutoMapper;
using BackEnd_WebApp_PastilleroAutomatico.Models.DTO;

namespace BackEnd_WebApp_PastilleroAutomatico.Models.Profiles
{
    public class FacturaProfile : Profile
    {
        public FacturaProfile()
        {
            CreateMap<Factura, FacturaDTO>();
            CreateMap<FacturaDTO, Factura>();
        }
    }
}
