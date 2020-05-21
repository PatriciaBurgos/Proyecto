using Abp.Application.Services.Dto;
using DAM.Publicaciones.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.Peticiones.Dto
{
	public class PeticionCreateDto 
	{
		public string PublicacionCategoria { get; set; }
		public string PublicacionTexto { get; set; }
		public double? PublicacionHorarioInicio { get; set; }
		public double? PublicacionHorarioFin { get; set; }
		public string PublicacionMunicipio { get; set; }
		public string PublicacionCiudad { get; set; }

		public bool IsUrgent { get; set; }
	}
}
