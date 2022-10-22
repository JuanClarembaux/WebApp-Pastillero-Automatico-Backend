using AutoMapper;
using BackEnd_WebApp_PastilleroAutomatico.Models.DTO;

namespace BackEnd_WebApp_PastilleroAutomatico.Models.Profiles
{
    public class UsuarioDireccionProfile : Profile
    {
        public UsuarioDireccionProfile()
        {
            CreateMap<UsuarioDireccion, UsuarioDireccionDTO>();
            CreateMap<UsuarioDireccionDTO, UsuarioDireccion>();
        }
    }
}
