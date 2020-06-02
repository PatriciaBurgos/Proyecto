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
			CreateMap<Chat, ChatDto>()
				.ForMember(c => c.UsuarioOrigen, opts => opts.MapFrom(c => c.UsuarioOrigen.UserName))
				.ForMember(c => c.UsuarioDestino, opts => opts.MapFrom(c => c.UsuarioDestino.UserName))
				.ReverseMap();

			CreateMap<Chat, ChatCreateDto>().ReverseMap();

			CreateMap<Chat, MostrarChatReducidoDto>()
				.ForMember(c => c.UsuarioOrigen, opts => opts.MapFrom(c => c.UsuarioOrigen.UserName))
				.ForMember(c => c.UsuarioDestino, opts => opts.MapFrom(c => c.UsuarioDestino.UserName))
				.ReverseMap();

		}
	}
}
