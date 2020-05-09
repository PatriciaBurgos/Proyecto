﻿using Abp.Application.Services.Dto;
using DAM.Publicaciones.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.Peticiones.Dto
{
	public class PeticionDto : EntityDto
	{
		public int PublicacionId { get; set; }
		public PublicacionReducidaDto Publicacion { get; set; }

		public bool IsUrgent { get; set; }
	}
}
