using Abp.Domain.Entities.Auditing;
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
	}
}
