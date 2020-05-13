using Abp.Application.Services.Dto;
using DAM.Usuarios.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.PublicacionesGustadas.Dto
{
	public class PublicacionGustadaDto : EntityDto
	{
		public UsuarioReducidoDto Usuario { get; set; }
	}
}
