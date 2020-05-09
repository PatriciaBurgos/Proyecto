using Abp.Domain.Entities.Auditing;
using DAM.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAM.UsuariosGustados
{
	public class UsuarioGustado : FullAuditedEntity
	{		
		public int UsuarioSeguidorId { get; set; }
		public Usuario UsuarioSeguidor { get; set; }
		public int UsuarioSeguidoId { get; set; }
		public Usuario UsuarioSeguido { get; set; }
		
	}
}
