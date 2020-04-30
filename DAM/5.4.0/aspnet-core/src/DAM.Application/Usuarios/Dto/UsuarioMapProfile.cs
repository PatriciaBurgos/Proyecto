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
		}
	}
}
