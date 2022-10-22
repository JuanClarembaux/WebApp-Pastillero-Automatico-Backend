using AutoMapper;
using BackEnd_WebApp_PastilleroAutomatico.Models.DTO;

namespace BackEnd_WebApp_PastilleroAutomatico.Models.Profiles
{
    public class FacturaDetalleProfile : Profile
    {
        public FacturaDetalleProfile()
        {
            CreateMap<FacturaDetalle, FacturaDetalleDTO>();
            CreateMap<FacturaDetalleDTO, FacturaDetalle>();
        }
    }
}
