using AutoMapper;
using BackEnd_WebApp_PastilleroAutomatico.Models.DTO;

namespace BackEnd_WebApp_PastilleroAutomatico.Models.Profiles
{
    public class UsuarioTelefonoProfile : Profile
    {
        public UsuarioTelefonoProfile()
        {
            CreateMap<UsuarioTelefono, UsuarioTelefonoDTO>();
            CreateMap<UsuarioTelefonoDTO, UsuarioTelefono>();
        }
    }
}
