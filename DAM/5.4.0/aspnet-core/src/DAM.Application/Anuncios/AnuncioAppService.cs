using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using DAM.Anuncios.Dto;
using DAM.Authorization;
using DAM.Authorization.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Anuncios
{
	[AbpAuthorize(PermissionNames.Pages_Anuncios)]
	public class AnuncioAppService : AsyncCrudAppService<Anuncio, AnuncioDto, int, PagedAnuncioResultRequestDto, AnuncioCreateDto, AnuncioDto>
	{
		private readonly IRepository<Anuncio> _anuncioRepository;
		private readonly UserManager _userManager;
		public AnuncioAppService(IRepository<Anuncio> repository, UserManager userManager) : base(repository)
		{
			_anuncioRepository = repository;
			_userManager = userManager;
		}

		public async Task<ListResultDto<AnuncioDto>> GetPublicacionesAnuncios()
		{
			var anuncios = await _anuncioRepository.GetAll()
				.Include(a => a.Publicacion)
				.ThenInclude(p => p.Usuario)
				.ToListAsync();

			return new ListResultDto<AnuncioDto>(ObjectMapper.Map<List<AnuncioDto>>(anuncios));
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
			var anuncios = await _anuncioRepository.GetAll()
				.Include(a => a.Publicacion)
				.Where(a => a.Publicacion.Ciudad == ciudad)
				.ToListAsync();				

			return new ListResultDto<AnuncioDto>(ObjectMapper.Map<List<AnuncioDto>>(anuncios));
		}

		public async Task<ListResultDto<AnuncioDto>> BusquedaAnunciosPorCategoria(string categoria)
		{
			var anuncios = await _anuncioRepository.GetAll()
				.Include(a => a.Publicacion)
				.Where(a => a.Publicacion.Categoria == categoria)
				.ToListAsync();

			return new ListResultDto<AnuncioDto>(ObjectMapper.Map<List<AnuncioDto>>(anuncios));
		}

	}
}
