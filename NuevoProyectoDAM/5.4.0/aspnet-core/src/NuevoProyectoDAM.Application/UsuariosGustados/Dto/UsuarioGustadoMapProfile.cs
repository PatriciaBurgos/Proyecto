using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using DAM.UsuariosGustados;
using NuevoProyectoDAM.UsuariosGustados.Dto;

namespace DAM.UsuarioGustados.Dto
{
	public class UsuarioGustadoMapProfile : Profile
	{
		public UsuarioGustadoMapProfile()
		{
			CreateMap<UsuarioGustado, UsuarioGustadoSeguidorDto>()
				.ForMember(p => p.Usuario, opts => opts.MapFrom(p => p.UsuarioSeguidor));

			CreateMap<UsuarioGustado, UsuarioGustadoSeguidoDto>()
				.ForMember(p => p.Usuario, opts => opts.MapFrom(p => p.UsuarioSeguido));
		}
	}
}
