using DAM.UsuarioGustados.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace NuevoProyectoDAM.Users.Dto
{
	public class UsuariosSeguidoresDto
	{
		public ICollection<UsuarioGustadoSeguidorDto> UsuariosSeguidores { get; set; }
		public int NumUsuarios { get; set; }
	}
}
