using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.UsuarioSeguidos.Dto
{
	public class PagedUsuarioGustadoResultRequestDto : PagedResultRequestDto
	{
		public string Keyword { get; set; }
	}
}
