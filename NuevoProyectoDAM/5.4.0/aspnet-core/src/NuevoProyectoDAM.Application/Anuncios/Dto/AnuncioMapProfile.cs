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
			CreateMap<Anuncio, AnuncioDto>().ForMember(an => an.Publicacion, opts => opts.MapFrom(p => p.Publicacion));

			CreateMap<Anuncio, AnuncioCreateDto>().ReverseMap();

			CreateMap<Anuncio, AnuncioGustaAUsuariosDto>()
				.ForMember(cdto => cdto.NumUsuarios, opts => opts.MapFrom(cb => cb.Publicacion.PublicacionesGustadas.Count > 0 ? cb.Publicacion.PublicacionesGustadas.Count : 0))
				.ForMember(a => a.UsuariosGustaAnuncio, opts => opts.MapFrom(a => a.Publicacion.PublicacionesGustadas));
		}

	}
}
