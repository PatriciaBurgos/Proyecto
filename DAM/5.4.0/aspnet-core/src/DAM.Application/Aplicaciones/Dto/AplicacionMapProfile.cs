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
			CreateMap<Aplicacion, AplicacionConVectorUsuariosDto>().ReverseMap();
		}
	}
}
