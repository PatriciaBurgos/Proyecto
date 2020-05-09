using Abp.Domain.Entities.Auditing;
using DAM.Publicaciones;
using DAM.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAM.Aplicaciones
{
	public class Aplicacion : FullAuditedEntity
	{
		[Required]
		public string Nombre { get; set; }

		public ICollection<Usuario> Usuarios { get; set; } 
		public ICollection<Publicacion> Publicaciones { get; set; }
	}
}
