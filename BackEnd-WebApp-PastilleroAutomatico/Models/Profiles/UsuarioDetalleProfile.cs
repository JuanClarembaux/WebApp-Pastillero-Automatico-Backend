using AutoMapper;
using BackEnd_WebApp_PastilleroAutomatico.Models.DTO;

namespace BackEnd_WebApp_PastilleroAutomatico.Models.Profiles
{
    public class UsuarioDetalleProfile : Profile
    {
        public UsuarioDetalleProfile()
        {
            CreateMap<UsuarioDetalle, UsuarioDetalleDTO>();
            CreateMap<UsuarioDetalleDTO, UsuarioDetalle>();
        }
    }
}
