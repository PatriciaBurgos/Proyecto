using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using NuevoProyectoDAM.Authorization;
using NuevoProyectoDAM.Authorization.Users;
using NuevoProyectoDAM.Users.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace NuevoProyectoDAM.Users
{
	[AbpAuthorize(PermissionNames.Pages_UsersNormales)]
	public class UsuarioLogadoAppService : ApplicationService 
	{
		private readonly IRepository<User,long> _userRepository;
		private readonly UserManager _userManager;
		
		public UsuarioLogadoAppService(IRepository<User,long> repository, UserManager userManager) 
		{
			_userRepository = repository;
			_userManager = userManager;
		}

		public async Task<UserDto> GetUsuarioLogado()
		{
			var usuarioActual = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());

			var usuario = await _userRepository.GetAll()
				.Where(u => u.Id == usuarioActual.Id)
				.FirstOrDefaultAsync();

			return ObjectMapper.Map<UserDto>(usuario);
		}

		public async Task<UsuariosSeguidoresDto> GetMisSeguidores()
		{
			var usuarioActual = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());

			var usuarios = await _userRepository.GetAll()
				.Include(u => u.UsuariosSeguidos)
				.ThenInclude(u => u.UsuarioSeguidor)
				.Where(u => u.Id == usuarioActual.Id)
				.FirstOrDefaultAsync();

			return ObjectMapper.Map<UsuariosSeguidoresDto>(usuarios);
		}

		public async Task<UsuariosSeguidoresDto> GetSeguidoresUsuario(int id)
		{
			var usuarios = await _userRepository.GetAll()
				.Include(u => u.UsuariosSeguidos)
				.ThenInclude(u => u.UsuarioSeguidor)
				.Where(u => u.Id == id)
				.FirstOrDefaultAsync();

			return ObjectMapper.Map<UsuariosSeguidoresDto>(usuarios);
		}

		public async Task<UsuariosSeguidosDto> GetMisSeguidos()
		{
			var usuarioActual = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());

			var usuarios = await _userRepository.GetAll()
				.Include(u => u.UsuariosSeguidores)
				.ThenInclude(u => u.UsuarioSeguido)
				.Where(u => u.Id == usuarioActual.Id)
				.FirstOrDefaultAsync();

			return ObjectMapper.Map<UsuariosSeguidosDto>(usuarios);
		}

		public async Task<UsuariosSeguidosDto> GetSeguidosUsuario(int id)
		{ 
			var usuarios = await _userRepository.GetAll()
				.Include(u => u.UsuariosSeguidores)
				.ThenInclude(u => u.UsuarioSeguido)
				.Where(u => u.Id == id)
				.FirstOrDefaultAsync();

			return ObjectMapper.Map<UsuariosSeguidosDto>(usuarios);
		}

		public async Task<UserDto> GetUsuarioAplicacion(int id)
		{			
			var usuario = await _userRepository.GetAll()
				.Where(u => u.Id == id)
				.FirstOrDefaultAsync();

			return ObjectMapper.Map<UserDto>(usuario);
		}

		public async Task<ListResultDto<UserDto>> GetAllUsuarios()
		{
			var usuarios = await _userRepository.GetAllListAsync();

			return new ListResultDto<UserDto>(ObjectMapper.Map<List<UserDto>>(usuarios));
		}

		
	}
}
