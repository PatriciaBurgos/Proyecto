using Abp.Application.Services.Dto;
using DAM.PublicacionesGustadas.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.Anuncios.Dto
{
	public class AnuncioGustaAUsuariosDto : EntityDto
	{
		public ICollection<PublicacionGustadaDto> UsuariosGustaAnuncio { get; set; }
		public int NumUsuarios { get; set; }
	}
}
