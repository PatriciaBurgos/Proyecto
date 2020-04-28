using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.Aplicaciones.Dto
{
	public class AplicacionDto : FullAuditedEntityDto
	{
		public string Nombre { get; set; }
	}
}
