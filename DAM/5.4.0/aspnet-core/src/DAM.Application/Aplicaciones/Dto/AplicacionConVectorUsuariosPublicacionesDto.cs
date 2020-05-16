using Abp.Application.Services.Dto;
using DAM.Publicaciones.Dto;
using DAM.Usuarios;
using DAM.Usuarios.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.Aplicaciones.Dto
{
	public class AplicacionConVectorUsuariosPublicacionesDto : EntityDto
	{
		public string Nombre { get; set; }

		public ICollection<UsuarioDto> Usuarios { get; set; }
		public int NumUsuarios { get; set; }
	}
}
