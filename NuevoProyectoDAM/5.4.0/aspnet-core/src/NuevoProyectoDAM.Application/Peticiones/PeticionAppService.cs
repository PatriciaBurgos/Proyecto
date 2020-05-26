using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using DAM.Peticiones.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NuevoProyectoDAM.Authorization;
using NuevoProyectoDAM.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Peticiones
{
	[AbpAuthorize(PermissionNames.Pages_Peticiones)]
	public class PeticionAppService : AsyncCrudAppService<Peticion, PeticionDto, int, PagedPeticionResultRequestDto, PeticionCreateDto, PeticionDto>
	{
		private readonly IRepository<Peticion> _peticionRepository;
		private readonly UserManager _userManager;
		public PeticionAppService(IRepository<Peticion> repository, UserManager userManager) : base(repository)
		{
			_peticionRepository = repository;
			_userManager = userManager;
		}

		public override async Task<PeticionDto> CreateAsync(PeticionCreateDto input)
		{
			CheckUpdatePermission();

			var usuarioActual = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());

			var peticion = ObjectMapper.Map<Peticion>(input);

			peticion.Publicacion.UsuarioId = usuarioActual.Id;

			await _peticionRepository.InsertAsync(peticion);
			await CurrentUnitOfWork.SaveChangesAsync();

			return ObjectMapper.Map<PeticionDto>(peticion);
		}

		public async Task<ListResultDto<PeticionDto>> GetPublicacionesPeticiones()
		{
			var peticiones = await _peticionRepository.GetAll()
				.Include(a => a.Publicacion)
				.ThenInclude(p => p.Usuario)
				.ToListAsync();

			return new ListResultDto<PeticionDto>(ObjectMapper.Map<List<PeticionDto>>(peticiones));
		}

		public async Task<ListResultDto<PeticionGustaAUsuariosDto>> GetUsuariosGustaPeticion(int id)
		{
			var usuarios = await _peticionRepository.GetAll()
				.Include(a => a.Publicacion)
				.ThenInclude(p => p.PublicacionesGustadas)
				.ThenInclude(p => p.Usuario)
				.Where(a => a.Id == id)
				.ToListAsync();

			return new ListResultDto<PeticionGustaAUsuariosDto>(ObjectMapper.Map<List<PeticionGustaAUsuariosDto>>(usuarios));
		}

		public async Task<ListResultDto<PeticionDto>> GetPeticionesUnUsuario(int id)
		{
			var peticiones = await _peticionRepository.GetAll()
				.Include(a => a.Publicacion)
				.ThenInclude(p => p.Usuario)
				.Where(a => a.Publicacion.Usuario.Id == id)
				.ToListAsync();

			return new ListResultDto<PeticionDto>(ObjectMapper.Map<List<PeticionDto>>(peticiones));
		}

		public async Task<ListResultDto<PeticionDto>> GetPeticionesUsuarioLogado()
		{
			var usuarioActual = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());

			var peticiones = await _peticionRepository.GetAll()
				.Include(a => a.Publicacion)
				.ThenInclude(p => p.Usuario)
				.Where(a => a.Publicacion.Usuario.Id == usuarioActual.Id)
				.ToListAsync();

			return new ListResultDto<PeticionDto>(ObjectMapper.Map<List<PeticionDto>>(peticiones));
		}

		public async Task<ListResultDto<PeticionDto>> BusquedaPeticionesPorMunicipio(string municipio)
		{
			var peticiones = await _peticionRepository.GetAll()
				.Include(a => a.Publicacion)
				.Where(a => a.Publicacion.Municipio == municipio)
				.ToListAsync();

			return new ListResultDto<PeticionDto>(ObjectMapper.Map<List<PeticionDto>>(peticiones));
		}

		public async Task<ListResultDto<PeticionDto>> BusquedaPeticionesPorCiudad(string ciudad)
		{
			var peticiones = await _peticionRepository.GetAll()
				.Include(a => a.Publicacion)
				.Where(a => a.Publicacion.Ciudad == ciudad)
				.ToListAsync();

			return new ListResultDto<PeticionDto>(ObjectMapper.Map<List<PeticionDto>>(peticiones));
		}

		public async Task<ListResultDto<PeticionDto>> BusquedaPeticionesPorCategoria(string categoria)
		{
			var peticiones = await _peticionRepository.GetAll()
				.Include(a => a.Publicacion)
				.Where(a => a.Publicacion.Categoria == categoria)
				.ToListAsync();

			return new ListResultDto<PeticionDto>(ObjectMapper.Map<List<PeticionDto>>(peticiones));
		}

		public async Task<ListResultDto<PeticionDto>> BusquedaPeticionesUrgentes(bool urgente)
		{
			var peticiones = await _peticionRepository.GetAll()
				.Include(a => a.Publicacion)
				.Where(p => p.IsUrgent == urgente)
				.ToListAsync();

			return new ListResultDto<PeticionDto>(ObjectMapper.Map<List<PeticionDto>>(peticiones));
		}
	}
}
