using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.Anuncios.Dto
{
	class AnuncioMapProfile : Profile
	{
		public AnuncioMapProfile()
		{
			CreateMap<Anuncio, AnuncioDto>().ReverseMap();
			CreateMap<Anuncio, AnuncioCreateDto>().ReverseMap();
		}

	}
}
