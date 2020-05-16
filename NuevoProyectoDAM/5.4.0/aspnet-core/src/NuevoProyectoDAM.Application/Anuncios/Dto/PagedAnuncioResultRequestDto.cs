using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.Anuncios.Dto
{
	public class PagedAnuncioResultRequestDto : PagedResultRequestDto
	{
		public string Keyword { get; set; }
	}
}
