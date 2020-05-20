using AutoMapper;
using DAM.Chats;
using System;
using System.Collections.Generic;
using System.Text;

namespace NuevoProyectoDAM.Chats.Dto
{
	public class ChatMapProfile : Profile
	{
		public ChatMapProfile()
		{
			CreateMap<Chat, ChatDto>().ReverseMap();

			CreateMap<Chat, ChatCreateDto>().ReverseMap();

			CreateMap<Chat, MostrarChatReducidoDto>().ReverseMap();

		}
	}
}
