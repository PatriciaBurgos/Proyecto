using Abp.Application.Services.Dto;
using NuevoProyectoDAM.Users.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.UsuarioGustados.Dto
{
	public class UsuarioGustadoSeguidorDto : EntityDto
	{
		public UserNameDto Usuario { get; set; }
	}
}
