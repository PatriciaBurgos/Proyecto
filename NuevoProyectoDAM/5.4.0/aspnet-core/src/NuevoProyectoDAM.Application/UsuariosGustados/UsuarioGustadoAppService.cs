using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using DAM.UsuariosGustados;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NuevoProyectoDAM.Authorization;
using NuevoProyectoDAM.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevoProyectoDAM.UsuariosGustados
{
	[AbpAuthorize(PermissionNames.Pages_UsersNormales)]
	public class UsuarioGustadoAppService : ApplicationService
	{
		private readonly IRepository<UsuarioGustado> _usuariosGustadosRepository;
		private readonly UserManager _userManager;
		public UsuarioGustadoAppService(IRepository<UsuarioGustado> repository, UserManager userManager)
		{
			_usuariosGustadosRepository = repository;
			_userManager = userManager;
		}

		public async Task UsuarioLogadoGustaUsuario(int idUser)
		{
			var usuarioActual = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());

			UsuarioGustado userGust = new UsuarioGustado();
			userGust.UsuarioSeguidorId = usuarioActual.Id;
			userGust.UsuarioSeguidoId = idUser;

			await _usuariosGustadosRepository.InsertAsync(userGust);
			await CurrentUnitOfWork.SaveChangesAsync();

		}

		public async Task UsuarioLogadoNOGustaUsuario(int idUser)
		{
			var usuarioActual = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());

			var userGust = await _usuariosGustadosRepository.GetAll()
				.Include(u => u.UsuarioSeguido)
				.Include(u => u.UsuarioSeguidor)
				.Where(u => u.UsuarioSeguidoId == idUser)
				.Where(u => u.UsuarioSeguidorId == usuarioActual.Id)
				.FirstOrDefaultAsync();

			await _usuariosGustadosRepository.DeleteAsync(userGust);
		}


	}
}
