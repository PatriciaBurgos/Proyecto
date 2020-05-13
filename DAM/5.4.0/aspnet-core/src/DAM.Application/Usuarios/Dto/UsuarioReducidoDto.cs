using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.Usuarios.Dto
{
	public class UsuarioReducidoDto : EntityDto
	{
		public string NombreUsuario { get; set; }
	}
}
