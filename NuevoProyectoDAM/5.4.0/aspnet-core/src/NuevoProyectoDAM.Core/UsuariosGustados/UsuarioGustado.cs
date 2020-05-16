using Abp.Domain.Entities.Auditing;
using NuevoProyectoDAM.Authorization.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAM.UsuariosGustados
{
	public class UsuarioGustado : FullAuditedEntity
	{		
		public long UsuarioSeguidorId { get; set; }
		public User UsuarioSeguidor { get; set; }
		public long UsuarioSeguidoId { get; set; }
		public User UsuarioSeguido { get; set; }
		
	}
}
