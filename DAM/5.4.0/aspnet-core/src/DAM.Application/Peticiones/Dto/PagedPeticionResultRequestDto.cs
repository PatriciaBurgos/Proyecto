using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.Peticiones.Dto
{
	public class PagedPeticionResultRequestDto : PagedResultRequestDto
	{
		public string Keyword { get; set; }
	}
}
