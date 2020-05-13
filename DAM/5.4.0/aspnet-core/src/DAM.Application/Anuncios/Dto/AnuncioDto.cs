using Abp.Application.Services.Dto;
using DAM.Publicaciones.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.Anuncios.Dto
{
	public class AnuncioDto : EntityDto
	{		
		public PublicacionDto Publicacion { get; set; }

		public string Preferencias { get; set; }
	}
}
