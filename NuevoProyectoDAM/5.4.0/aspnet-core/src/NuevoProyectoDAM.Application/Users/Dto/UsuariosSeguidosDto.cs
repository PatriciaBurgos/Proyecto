using NuevoProyectoDAM.Sessions.Dto;
using NuevoProyectoDAM.UsuariosGustados.Dto;
using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;

namespace NuevoProyectoDAM.Users.Dto
{
	public class UsuariosSeguidosDto
	{
		public ICollection<UsuarioGustadoSeguidoDto> UsuariosSeguidos { get; set; }
		public int NumUsuarios { get; set; }

	}
}
