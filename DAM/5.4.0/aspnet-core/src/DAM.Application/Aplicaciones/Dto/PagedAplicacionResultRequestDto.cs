using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.Aplicaciones.Dto
{
	public class PagedAplicacionResultRequestDto : PagedResultRequestDto
	{
		public  string Keyword { get; set; }
	}
}
