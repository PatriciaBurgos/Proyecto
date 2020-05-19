using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Microsoft.EntityFrameworkCore;
using NuevoProyectoDAM.Authorization;
using NuevoProyectoDAM.Authorization.Users;
using NuevoProyectoDAM.Users.Dto;
using System;
using System.Collections.Generic;
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

	}
}
