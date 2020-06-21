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

		/// <summary>
		/// Creación de un anuncio
		/// </summary>
		/// <param name="input">Datos del nuevo anuncio</param>
		/// <returns>Objeto anuncio creado</returns>
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

		/// <summary>
		/// Consulta de todos los anuncios
		/// </summary>
		/// <returns>Lista de todos los anuncios creados</returns>
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

		/// <summary>
		/// Consulta de un anuncio
		/// </summary>
		/// <param name="id">Id del anuncio a consultar</param>
		/// <returns>Objeto anuncio encontrado</returns>
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

		/// <summary>
		/// Consulta de los usuarios que les gusta un anuncio
		/// </summary>
		/// <param name="id">Id del anuncio a consultar</param>
		/// <returns>Todos los usuarios a los que les gusta el anuncio</returns>
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

		/// <summary>
		/// Consulta de todos los anuncios publicados de un usuario
		/// </summary>
		/// <param name="id">Identificador del usuario</param>
		/// <returns>Lista de todos los anuncios del usuario</returns>
		public async Task<ListResultDto<AnuncioDto>> GetAnunciosUnUsuario(int id)
		{
			var anuncios = await _anuncioRepository.GetAll()
				.Include(a => a.Publicacion)
				.ThenInclude(p => p.Usuario)
				.Where(a => a.Publicacion.Usuario.Id == id)
				.ToListAsync();

			return new ListResultDto<AnuncioDto>(ObjectMapper.Map<List<AnuncioDto>>(anuncios));
		}

		/// <summary>
		/// Consulta de todos los anuncios publicados por el usuario logado
		/// </summary>
		/// <returns>Lista de todos los anuncios del usuario logado</returns>
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

		/// <summary>
		/// Busqueda de todos los anuncios que tengan el municipio del parametro
		/// </summary>
		/// <param name="municipio">Nombre del municipio</param>
		/// <returns>Lista de los anuncios con ese municipio</returns>
		public async Task<ListResultDto<AnuncioDto>> BusquedaAnunciosPorMunicipio(string municipio)
		{
			var usuarioActual = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());

			var anuncios = await _anuncioRepository.GetAll()
				.Include(a => a.Publicacion)
				.ThenInclude(p => p.PublicacionesGustadas)
				.ThenInclude(p => p.Usuario)
				.Include(a => a.Publicacion.Usuario)
				.Where(a => a.Publicacion.Municipio == municipio)
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

		/// <summary>
		/// Busqueda de todos los anuncios que tengan la ciudad del parámetro
		/// </summary>
		/// <param name="ciudad">Nombre de la ciudad</param>
		/// <returns>Lista de los anuncios con esa ciudad</returns>
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

		/// <summary>
		/// Busqueda de anuncios por una categoría concreta
		/// </summary>
		/// <param name="categoria">Nombre de la categoría</param>
		/// <returns>Lista de los anuncios con esa categoría</returns>
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

		/// <summary>
		/// Busqueda de anuncios por el horario de inicio 
		/// </summary>
		/// <param name="horIni">Hora de inicio del anuncio</param>
		/// <returns>Lista de los anuncios con ese horario de inicio</returns>
		public async Task<ListResultDto<AnuncioDto>> BusquedaAnunciosPorHorarioInicio(double horIni)
		{
			var usuarioActual = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());

			var anuncios = await _anuncioRepository.GetAll()
				.Include(a => a.Publicacion)
				.ThenInclude(p => p.PublicacionesGustadas)
				.ThenInclude(p => p.Usuario)
				.Include(a => a.Publicacion.Usuario)
				.Where(a => a.Publicacion.HorarioInicio == horIni)
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

		/// <summary>
		/// Busqueda de anuncios por el usuario que los ha creado
		/// </summary>
		/// <param name="userNam">Nombre de usuario del creador del anuncio</param>
		/// <returns>Lista de los anuncios de ese usuario</returns>
		public async Task<ListResultDto<AnuncioDto>> BusquedaAnunciosPorUsuario(string userNam)
		{
			var usuarioActual = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());

			var anuncios = await _anuncioRepository.GetAll()
				.Include(a => a.Publicacion)
				.ThenInclude(p => p.PublicacionesGustadas)
				.ThenInclude(p => p.Usuario)
				.Include(a => a.Publicacion.Usuario)
				.Where(a => a.Publicacion.Usuario.UserName == userNam)
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
