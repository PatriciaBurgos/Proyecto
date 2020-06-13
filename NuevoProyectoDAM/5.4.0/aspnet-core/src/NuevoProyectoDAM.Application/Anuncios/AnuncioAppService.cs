using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using AutoMapper;
using DAM.Anuncios.Dto;
using DAM.PublicacionesGustadas;
using DAM.PublicacionesGustadas.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using NuevoProyectoDAM.Authorization;
using NuevoProyectoDAM.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Anuncios
{
	[AbpAuthorize(PermissionNames.Pages_Anuncios)]
	public class AnuncioAppService :  AsyncCrudAppService<Anuncio, AnuncioDto, int, PagedAnuncioResultRequestDto, AnuncioCreateDto, AnuncioDto>
	{
		private readonly IRepository<Anuncio> _anuncioRepository;
		private readonly UserManager _userManager;
		public AnuncioAppService(IRepository<Anuncio> repository, UserManager userManager) : base(repository)
		{
			_anuncioRepository = repository;
			_userManager = userManager;
		}

		public override async Task<AnuncioDto> CreateAsync(AnuncioCreateDto input)
		{
			CheckUpdatePermission();

			var usuarioActual = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());

			var anuncio = ObjectMapper.Map<Anuncio>(input);

			anuncio.Publicacion.UsuarioId = usuarioActual.Id;

			await _anuncioRepository.InsertAsync(anuncio);
			await CurrentUnitOfWork.SaveChangesAsync();

			return ObjectMapper.Map<AnuncioDto>(anuncio);
		}


		public async Task<ListResultDto<AnuncioDto>> GetPublicacionesAnuncios()
		{
			CheckUpdatePermission();

			var usuarioActual = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());

			var anuncios = await _anuncioRepository.GetAll()
				.Include(a => a.Publicacion)
				.ThenInclude(p => p.PublicacionesGustadas)
				.ThenInclude(p => p.Usuario)
				.Include(a => a.Publicacion.Usuario)
				.ToListAsync();

			var anunciosDto = new List<AnuncioDto>(ObjectMapper.Map<List<AnuncioDto>>(anuncios));


			foreach (AnuncioDto anun in anunciosDto)
			{				 
				foreach (PublicacionGustadaDto publiGus in anun.UsuariosGustaAnuncio)
				{
					if (usuarioActual.Id == publiGus.Usuario.Id)
					{
						anun.usuarioActualGustaPublicacion = true;
					}
				}
				
			}

			return new ListResultDto<AnuncioDto>(ObjectMapper.Map<List<AnuncioDto>>(anunciosDto));
		}


		public async Task<AnuncioDto> GetUnAnuncio(int id)
		{
			var usuarioActual = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());

			var anuncio = await _anuncioRepository.GetAll()
				.Include(a => a.Publicacion)
				.ThenInclude(p => p.PublicacionesGustadas)
				.ThenInclude(p => p.Usuario)
				.Include(a => a.Publicacion.Usuario)
				.Where(a => a.Id == id)
				.FirstOrDefaultAsync();

			var anunDto = ObjectMapper.Map<AnuncioDto>(anuncio);

			foreach (PublicacionGustadaDto publiGus in anunDto.UsuariosGustaAnuncio)
			{
				if (usuarioActual.Id == publiGus.Usuario.Id)
				{
					anunDto.usuarioActualGustaPublicacion = true;
				}
			}

			return ObjectMapper.Map<AnuncioDto>(anunDto);
		}

		public async Task<ListResultDto<AnuncioGustaAUsuariosDto>> GetUsuariosGustaAnuncio(int id)
		{ 
			var usuarios = await _anuncioRepository.GetAll()
				.Include(a => a.Publicacion)
				.ThenInclude(p => p.PublicacionesGustadas)	
				.ThenInclude(p => p.Usuario)
				.Where(a => a.Id == id)
				.ToListAsync();

			return new ListResultDto<AnuncioGustaAUsuariosDto>(ObjectMapper.Map<List<AnuncioGustaAUsuariosDto>>(usuarios));
		}

		public async Task<ListResultDto<AnuncioDto>> GetAnunciosUnUsuario(int id)
		{
			var anuncios = await _anuncioRepository.GetAll()
				.Include(a => a.Publicacion)
				.ThenInclude(p => p.Usuario)
				.Where(a => a.Publicacion.Usuario.Id == id)
				.ToListAsync();

			return new ListResultDto<AnuncioDto>(ObjectMapper.Map<List<AnuncioDto>>(anuncios));
		}

		public async Task<ListResultDto<AnuncioDto>> GetAnunciosUsuarioLogado()
		{
			var usuarioActual = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());

			var anuncios = await _anuncioRepository.GetAll()
				.Include(a => a.Publicacion)
				.ThenInclude(p => p.Usuario)
				.Where(a => a.Publicacion.Usuario.Id == usuarioActual.Id)
				.ToListAsync();

			return new ListResultDto<AnuncioDto>(ObjectMapper.Map<List<AnuncioDto>>(anuncios));
		}

		public async Task<ListResultDto<AnuncioDto>> BusquedaAnunciosPorMunicipio(string municipio)
		{
			var anuncios = await _anuncioRepository.GetAll()
				.Include(a => a.Publicacion)
				.Where(a => a.Publicacion.Municipio == municipio)
				.ToListAsync();

			return new ListResultDto<AnuncioDto>(ObjectMapper.Map<List<AnuncioDto>>(anuncios));
		}

		public async Task<ListResultDto<AnuncioDto>> BusquedaAnunciosPorCiudad(string ciudad)
		{
			var usuarioActual = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());

			var anuncios = await _anuncioRepository.GetAll()
				.Include(a => a.Publicacion)
				.ThenInclude(p => p.PublicacionesGustadas)
				.ThenInclude(p => p.Usuario)
				.Include(a => a.Publicacion.Usuario)
				.Where(a => a.Publicacion.Ciudad == ciudad)
				.ToListAsync();

			var anunciosDto = new List<AnuncioDto>(ObjectMapper.Map<List<AnuncioDto>>(anuncios));


			foreach (AnuncioDto anun in anunciosDto)
			{
				foreach (PublicacionGustadaDto publiGus in anun.UsuariosGustaAnuncio)
				{
					if (usuarioActual.Id == publiGus.Usuario.Id)
					{
						anun.usuarioActualGustaPublicacion = true;
					}
				}

			}

			return new ListResultDto<AnuncioDto>(ObjectMapper.Map<List<AnuncioDto>>(anunciosDto));
		}

		public async Task<ListResultDto<AnuncioDto>> BusquedaAnunciosPorCategoria(string categoria)
		{
			var usuarioActual = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());

			var anuncios = await _anuncioRepository.GetAll()
				.Include(a => a.Publicacion)
				.ThenInclude(p => p.PublicacionesGustadas)
				.ThenInclude(p => p.Usuario)
				.Include(a => a.Publicacion.Usuario)
				.Where(a => a.Publicacion.Categoria == categoria)
				.ToListAsync();

			var anunciosDto = new List<AnuncioDto>(ObjectMapper.Map<List<AnuncioDto>>(anuncios));


			foreach (AnuncioDto anun in anunciosDto)
			{
				foreach (PublicacionGustadaDto publiGus in anun.UsuariosGustaAnuncio)
				{
					if (usuarioActual.Id == publiGus.Usuario.Id)
					{
						anun.usuarioActualGustaPublicacion = true;
					}
				}

			}

			return new ListResultDto<AnuncioDto>(ObjectMapper.Map<List<AnuncioDto>>(anunciosDto));
		}

	}
}
