using Abp.Domain.Entities.Auditing;
using DAM.Publicaciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.Peticiones
{
	public class Peticion : FullAuditedEntity
	{
		public bool IsUrgent { get; set; }

		public int PublicacionId { get; set; }
		public Publicacion Publicacion { get; set; }
	}
}
