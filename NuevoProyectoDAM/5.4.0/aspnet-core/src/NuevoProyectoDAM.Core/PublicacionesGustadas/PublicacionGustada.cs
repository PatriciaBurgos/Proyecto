using Abp.Domain.Entities.Auditing;
using NuevoProyectoDAM.Authorization.Users;
using DAM.Publicaciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.PublicacionesGustadas
{
	public class PublicacionGustada : FullAuditedEntity
	{
		public long UsuarioId { get; set; }
		public User Usuario { get; set; }
		public int PublicacionId { get; set; }
		public Publicacion Publicacion { get; set; }
		
	}
}
