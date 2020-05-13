using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.Aplicaciones.Dto
{
	public class AplicacionMapProfile : Profile
	{
		public AplicacionMapProfile()
		{
			CreateMap<Aplicacion, AplicacionDto>().ReverseMap();

			CreateMap<Aplicacion, AplicacionConVectorUsuariosPublicacionesDto>().ForMember(ap => ap.Usuarios, opts => opts.MapFrom(u => u.Usuarios))
				.ForMember(ap => ap.Publicaciones, opts => opts.MapFrom(p => p.Publicaciones));

			CreateMap<Aplicacion, AplicacionConVectorUsuariosPublicacionesDto>()
			   .ForMember(cdto => cdto.NumUsuarios, opts => opts.MapFrom(cb => cb.Usuarios.Count > 0 ? cb.Usuarios.Count : 0))
			   .ForMember(cdto => cdto.NumPublicaciones, opts => opts.MapFrom(cb => cb.Publicaciones.Count > 0 ? cb.Publicaciones.Count : 0));


		}
	}
}
