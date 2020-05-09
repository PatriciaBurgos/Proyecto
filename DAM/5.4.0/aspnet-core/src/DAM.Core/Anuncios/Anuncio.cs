using Abp.Domain.Entities.Auditing;
using DAM.Publicaciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.Anuncios
{
	public class Anuncio : FullAuditedEntity
	{
		public string Preferencias { get; set; }

		public int PublicacionId { get; set; }
		public Publicacion Publicacion { get; set; }
	}
}
