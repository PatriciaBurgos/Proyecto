using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.PublicacionesGustadas.Dto
{
	public class PublicacionGustadaMapProfile : Profile
	{
		public PublicacionGustadaMapProfile()
		{
			CreateMap<PublicacionGustada, PublicacionGustadaDto>()
				.ForMember(p => p.Usuario, opts => opts.MapFrom(p => p.Usuario));
		}
	}
}
