using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using DAM.PublicacionesGustadas;
using DAM.PublicacionesGustadas.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NuevoProyectoDAM.Authorization;
using NuevoProyectoDAM.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuevoProyectoDAM.PublicacionesGustadas
{

	[AbpAuthorize(PermissionNames.Pages_Publicaciones)]
	public class PublicacionGustadaAppService : ApplicationService
	{
		private readonly IRepository<PublicacionGustada> _publicacionesGustadasRepository;
		private readonly UserManager _userManager;
		public PublicacionGustadaAppService(IRepository<PublicacionGustada> repository, UserManager userManager)
		{
			_publicacionesGustadasRepository = repository;
			_userManager = userManager;
		}

		/// <summary>
		/// Crea el favorito entre el usuario logado y una publicación
		/// </summary>
		/// <param name="idPublicacion">Identificador de la publicación gustada</param>
		/// <returns></returns>
		public async Task UsuarioLogadoGustaPublicacion(int idPublicacion)
		{			
			var usuarioActual = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());

			PublicacionGustada publiGustada = new PublicacionGustada();
			publiGustada.PublicacionId = idPublicacion;
			publiGustada.UsuarioId = usuarioActual.Id;

			await _publicacionesGustadasRepository.InsertAsync(publiGustada);
			await CurrentUnitOfWork.SaveChangesAsync();
						
		}

		/// <summary>
		/// Deshace el favorito de un usuario a una publicación
		/// </summary>
		/// <param name="idPublicacion">Identificador de la publicación no gustada</param>
		/// <returns></returns>
		public async Task UsuarioLogadoNOGustaPublicacion(int idPublicacion)
		{
			var usuarioActual = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());

			var publiGustada = await _publicacionesGustadasRepository.GetAll()
				.Include(p => p.Publicacion)
				.Include(p => p.Usuario)
				.Where(p => p.UsuarioId == usuarioActual.Id)
				.Where(p => p.PublicacionId == idPublicacion)
				.FirstOrDefaultAsync();

			await _publicacionesGustadasRepository.DeleteAsync(publiGustada);
		}
	}
}
