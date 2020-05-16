using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using DAM.UsuariosGustados;
using DAM.UsuarioGustados.Dto;

namespace DAM.UsuarioGustados.Dto
{
	public class UsuarioGustadoMapProfile : Profile
	{
		public UsuarioGustadoMapProfile()
		{
			CreateMap<UsuarioGustado, UsuarioGustadoDto>().ReverseMap();
		}
	}
}
