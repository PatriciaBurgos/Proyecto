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
			CreateMap<Publicacion, PublicacionDto>().ReverseMap();
			CreateMap<Publicacion, PublicacionReducidaDto>().ReverseMap();
		}
	}
}
