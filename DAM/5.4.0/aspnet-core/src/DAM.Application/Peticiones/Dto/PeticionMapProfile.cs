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
			CreateMap<Peticion, PeticionDto>().ReverseMap();
			CreateMap<Peticion, PeticionCreateDto>().ReverseMap();
		}
	}
}
