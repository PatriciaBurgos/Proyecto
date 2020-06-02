using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using DAM.Chats;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NuevoProyectoDAM.Authorization;
using NuevoProyectoDAM.Authorization.Users;
using NuevoProyectoDAM.Chats.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace NuevoProyectoDAM.Chats
{
	[AbpAuthorize(PermissionNames.Pages_Chats)]
	public class ChatAppService : AsyncCrudAppService<Chat, ChatDto, int, PagedChatResultRequestDto, ChatCreateDto, ChatDto>
	{
		private readonly IRepository<Chat> _chatRepository;
		private readonly UserManager _userManager;

		public ChatAppService(IRepository<Chat> repository, UserManager userManager) : base(repository)
		{
			_chatRepository = repository;
			_userManager = userManager;
		}

		public override async Task<ChatDto> CreateAsync(ChatCreateDto input)
		{
			CheckUpdatePermission();

			var usuarioActual = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());
			var usuarioDestino = await _userManager.FindByNameOrEmailAsync(input.UserName);

			var chat = ObjectMapper.Map<Chat>(input);

			chat.UsuarioOrigenId = usuarioActual.Id;
			chat.IsEnviado = true;
			chat.FechaHora = DateTime.Now;
			chat.UsuarioDestino = usuarioDestino;

			await _chatRepository.InsertAsync(chat);
			await CurrentUnitOfWork.SaveChangesAsync();

			return ObjectMapper.Map<ChatDto>(chat);
		}

		public async Task<ListResultDto<MostrarChatReducidoDto>> GetUsuariosConLosQueHabla()
		{
			CheckUpdatePermission();

			var usuarioActual = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());

			var chatsOrigen = await _chatRepository.GetAll()
				.Include(c => c.UsuarioDestino)
				.Where(c => c.UsuarioOrigenId == usuarioActual.Id)
				.ToListAsync();
			

			var chatsDestino = await _chatRepository.GetAll()
				.Include(c => c.UsuarioOrigen)
				.Where(c => c.UsuarioDestinoId == usuarioActual.Id)
				.ToListAsync();

			var chats = chatsOrigen.Union(chatsDestino).OrderByDescending(c => c.FechaHora).ToList();

			ObjectMapper.Map<List<MostrarChatReducidoDto>>(chats);
			List<Chat> chatsDefinitivos = new List<Chat>();

			
			var amigo = "";
			var num = 0;

			for (int f = 0; f < chats.Count; f++)
			{	
				if(chats[0].UsuarioOrigen.UserName != usuarioActual.UserName)
				{
					amigo = chats[0].UsuarioOrigen.UserName;
				}
				else
				{
					amigo = chats[0].UsuarioDestino.UserName;
				}
				chatsDefinitivos.Add(chats[0]);

				for (int i = 0; i < chats.Count; i++)
				{
					if(amigo == chats[i].UsuarioOrigen.UserName || amigo == chats[i].UsuarioDestino.UserName)
					{
						chats.RemoveAt(i);
						num++;
						i--;
					}
					
				}
				if (num != 0)
				{
					f--;
					num = 0;
				}

			}

			return new ListResultDto<MostrarChatReducidoDto>(ObjectMapper.Map<List<MostrarChatReducidoDto>>(chatsDefinitivos));
		}

		public async Task<ListResultDto<ChatDto>> GetChatDosUsuarios (string userDestino)
		{
			CheckUpdatePermission();

			var usuarioActual = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());

			var chat = await _chatRepository.GetAll()
				.Include(c => c.UsuarioOrigen)
				.Include(c => c.UsuarioDestino)
				.Where(c => c.UsuarioOrigenId == usuarioActual.Id || c.UsuarioDestinoId == usuarioActual.Id)
				.Where(c => c.UsuarioOrigen.UserName == userDestino || c.UsuarioDestino.UserName == userDestino)
				.ToListAsync();

			return new ListResultDto<ChatDto>(ObjectMapper.Map<List<ChatDto>>(chat));
		}

		public async Task<ListResultDto<ChatDto>> GetChatCompletoDosUsuarios(int idChat)
		{
			CheckUpdatePermission();

			var usuarioActual = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());

			var chat = await _chatRepository.GetAll()
				.Include(c => c.UsuarioOrigen)
				.Include(c => c.UsuarioDestino)
				.Where(c => c.Id == idChat)
				.FirstOrDefaultAsync();

			long uOrigen = chat.UsuarioOrigenId;
			long uDestino = chat.UsuarioDestinoId;

			var chats = await _chatRepository.GetAll()
				.Include(c => c.UsuarioOrigen)
				.Include(c => c.UsuarioDestino)
				.Where(c => c.UsuarioOrigenId == uOrigen || c.UsuarioOrigenId == uDestino) 
				.Where(c => c.UsuarioDestinoId == uOrigen || c.UsuarioDestinoId == uDestino)
				.ToListAsync();

			return new ListResultDto<ChatDto>(ObjectMapper.Map<List<ChatDto>>(chats));
		}
	}
}
