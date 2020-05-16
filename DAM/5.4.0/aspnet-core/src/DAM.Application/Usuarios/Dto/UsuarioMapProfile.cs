using AutoMapper;
using DAM.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.Usuarios.Dto
{
	public class UsuarioMapProfile : Profile
	{
		public UsuarioMapProfile()
		{
			CreateMap<User, UsuarioDto>().ReverseMap();

			CreateMap<User, UsuarioAplicacionDto>().ReverseMap();

			CreateMap<User, UsuarioReducidoDto>()
				.ForMember(u => u.NombreUsuario, opts => opts.MapFrom(u => u.UserName));

			CreateMap<User, UsuarioCreateDto>().ReverseMap();
				//.ForMember(u => u.AplicacionId, opts => opts.MapFrom(u => u.Aplicacion.Id));
		}
	}
}
