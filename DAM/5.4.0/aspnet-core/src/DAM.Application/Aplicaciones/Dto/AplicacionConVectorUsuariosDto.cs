using Abp.Application.Services.Dto;
using DAM.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.Aplicaciones.Dto
{
	public class AplicacionConVectorUsuariosDto : EntityDto
	{
		public string Nombre { get; set; }

		public ICollection<Usuario> Usuario { get; set; }
	}
}
