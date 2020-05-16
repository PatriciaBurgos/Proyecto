using Abp.Application.Services.Dto;
using DAM.PublicacionesGustadas.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.Peticiones.Dto
{
	public class PeticionGustaAUsuariosDto : EntityDto
	{
		public ICollection<PublicacionGustadaDto> UsuariosGustaPeticion { get; set; }
		public int NumUsuarios { get; set; }
	}
}
