using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.Publicaciones.Dto
{
	class PublicacionMapProfile : Profile
	{
		public PublicacionMapProfile()
		{
			CreateMap<Publicacion, PublicacionDto>()
				.ForMember(p => p.NombreUsuario, opts => opts.MapFrom(p => p.Usuario.UserName));

			CreateMap<Publicacion, PublicacionReducidaDto>().ReverseMap();

			CreateMap<Publicacion, PublicacionCreateDto>().ReverseMap();
		}
	}
}
