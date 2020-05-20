using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace NuevoProyectoDAM.Chats.Dto
{
	public class PagedChatResultRequestDto : PagedResultRequestDto
	{
		public string Keyword { get; set; }
	}
}
