using AutoMapper;
using NuevoProyectoDAM.Authorization.Users;

namespace NuevoProyectoDAM.Users.Dto
{
    public class UserMapProfile : Profile
    {
        public UserMapProfile()
        {
            CreateMap<UserDto, User>();
            CreateMap<UserDto, User>()
                .ForMember(x => x.Roles, opt => opt.Ignore())
                .ForMember(x => x.CreationTime, opt => opt.Ignore());

            CreateMap<CreateUserDto, User>();
            CreateMap<CreateUserDto, User>().ForMember(x => x.Roles, opt => opt.Ignore());

            CreateMap<UserNameDto, User>().ReverseMap();

            CreateMap<User, UsuariosSeguidosDto>()
                .ForMember(u => u.UsuariosSeguidos, opts => opts.MapFrom(u => u.UsuariosSeguidores))
                .ForMember(u => u.NumUsuarios, opts => opts.MapFrom(u => u.UsuariosSeguidores.Count > 0 ? u.UsuariosSeguidores.Count : 0))
                .ReverseMap();

            CreateMap<User, UsuariosSeguidoresDto>()
                .ForMember(u => u.UsuariosSeguidores, opts => opts.MapFrom(u => u.UsuariosSeguidos))
                .ForMember(u => u.NumUsuarios, opts => opts.MapFrom(u => u.UsuariosSeguidos.Count > 0 ? u.UsuariosSeguidos.Count : 0))
                .ReverseMap();

        }
    }
}
