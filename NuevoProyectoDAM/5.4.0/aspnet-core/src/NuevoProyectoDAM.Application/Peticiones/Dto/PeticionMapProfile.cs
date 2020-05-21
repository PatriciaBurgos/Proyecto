using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.Peticiones.Dto
{
	public class PeticionMapProfile : Profile
	{
		public PeticionMapProfile()
		{
			CreateMap<Peticion, PeticionDto>()
				.ForMember(a => a.PublicacionNombreUsuario, opts => opts.MapFrom(a => a.Publicacion.Usuario.UserName))
				.ReverseMap();

			CreateMap<Peticion, PeticionCreateDto>().ReverseMap();

			CreateMap<Peticion, PeticionGustaAUsuariosDto>()
				.ForMember(cdto => cdto.NumUsuarios, opts => opts.MapFrom(cb => cb.Publicacion.PublicacionesGustadas.Count > 0 ? cb.Publicacion.PublicacionesGustadas.Count : 0))
				.ForMember(a => a.UsuariosGustaPeticion, opts => opts.MapFrom(a => a.Publicacion.PublicacionesGustadas));

		}
	}
}
