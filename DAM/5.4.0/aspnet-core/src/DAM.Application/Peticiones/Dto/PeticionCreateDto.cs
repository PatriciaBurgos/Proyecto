using Abp.Application.Services.Dto;
using DAM.Publicaciones.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.Peticiones.Dto
{
	public class PeticionCreateDto : EntityDto
	{
		public PublicacionCreateDto Publicacion { get; set; }

		public bool IsUrgent { get; set; }
	}
}
