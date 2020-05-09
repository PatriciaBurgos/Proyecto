using Abp.Application.Services.Dto;
using DAM.Publicaciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.Peticiones.Dto
{
	public class PeticionCreateDto : EntityDto
	{
		public Publicacion Publicacion { get; set; }

		public bool IsUrgent { get; set; }
	}
}
