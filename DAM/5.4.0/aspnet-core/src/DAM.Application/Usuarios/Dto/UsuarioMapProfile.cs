using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.Usuarios.Dto
{
	public class UsuarioMapProfile : Profile
	{
		public UsuarioMapProfile()
		{
			CreateMap<Usuario, UsuarioDto>().ReverseMap();

			CreateMap<Usuario, UsuarioAplicacionDto>().ReverseMap();

			CreateMap<Usuario, UsuarioReducidoDto>()
				.ForMember(u => u.NombreUsuario, opts => opts.MapFrom(u => u.NombreUsuario));

			CreateMap<Usuario, UsuarioCreateDto>().ReverseMap();
				//.ForMember(u => u.AplicacionId, opts => opts.MapFrom(u => u.Aplicacion.Id));
		}
	}
}
