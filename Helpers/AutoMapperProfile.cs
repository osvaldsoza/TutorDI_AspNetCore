using AutoMapper;
using TutorDI.Dtos;
using TutorDI.Model;

namespace TutorDI.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Usuario, UsuarioDTO>();
        }
    }
}