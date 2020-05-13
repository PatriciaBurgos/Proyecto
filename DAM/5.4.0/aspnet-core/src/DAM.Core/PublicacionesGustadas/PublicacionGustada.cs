using Abp.Domain.Entities.Auditing;
using DAM.Publicaciones;
using DAM.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.PublicacionesGustadas
{
	public class PublicacionGustada : FullAuditedEntity
	{
		public int UsuarioId { get; set; }
		public Usuario Usuario { get; set; }
		public int PublicacionId { get; set; }
		public Publicacion Publicacion { get; set; }
		
	}
}
