using Abp.Domain.Entities.Auditing;
using DAM.Authorization.Users;
//using DAM.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAM.UsuariosGustados
{
	public class UsuarioGustado : FullAuditedEntity
	{		
		public int UsuarioSeguidorId { get; set; }
		public User UsuarioSeguidor { get; set; }
		public int UsuarioSeguidoId { get; set; }
		public User UsuarioSeguido { get; set; }
		
	}
}
