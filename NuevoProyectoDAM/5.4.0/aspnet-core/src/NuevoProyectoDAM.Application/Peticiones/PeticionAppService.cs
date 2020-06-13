using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using DAM.Peticiones.Dto;
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
			CheckUpdatePermission();

			var usuarioActual = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());

			var peticiones = await _peticionRepository.GetAll()
				.Include(a => a.Publicacion)				
				.ThenInclude(p => p.PublicacionesGustadas)
				.ThenInclude(p => p.Usuario)
				.Include(a => a.Publicacion.Usuario)
				.ToListAsync();

			var peticionesDto = new List<PeticionDto>(ObjectMapper.Map<List<PeticionDto>>(peticiones));


			foreach (PeticionDto peti in peticionesDto)
			{
				foreach (PublicacionGustadaDto publiGus in peti.UsuariosGustaPeticion)
				{
					if(usuarioActual.Id == publiGus.Usuario.Id)
					{
						peti.usuarioActualGustaPublicacion = true;
					}
				}
			}

			return new ListResultDto<PeticionDto>(ObjectMapper.Map<List<PeticionDto>>(peticionesDto));
		}

		public async Task<PeticionDto> GetUnaPeticion(int id)
		{
			var usuarioActual = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());

			var peticion = await _peticionRepository.GetAll()
				.Include(a => a.Publicacion)
				.ThenInclude(p => p.PublicacionesGustadas)
				.ThenInclude(p => p.Usuario)
				.Include(p => p.Publicacion.Usuario)
				.Where(a => a.Id == id)
				.FirstOrDefaultAsync();

			var petiDto = ObjectMapper.Map<PeticionDto>(peticion);

			foreach (PublicacionGustadaDto publiGus in petiDto.UsuariosGustaPeticion)
			{
				if (usuarioActual.Id == publiGus.Usuario.Id)
				{
					petiDto.usuarioActualGustaPublicacion = true;
				}
			}


			return ObjectMapper.Map<PeticionDto>(petiDto);
		}

		/*public async Task<ListResultDto<PeticionGustaAUsuariosDto>> GetUsuariosGustaPeticion(int id)
		{
			var usuarios = await _peticionRepository.GetAll()
				.Include(a => a.Publicacion)
				.ThenInclude(p => p.PublicacionesGustadas)
				.ThenInclude(p => p.Usuario)
				.Where(a => a.Id == id)
				.ToListAsync();

			return new ListResultDto<PeticionGustaAUsuariosDto>(ObjectMapper.Map<List<PeticionGustaAUsuariosDto>>(usuarios));
		}*/


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
			var usuarioActual = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());

			var peticiones = await _peticionRepository.GetAll()
				.Include(a => a.Publicacion)
				.ThenInclude(p => p.PublicacionesGustadas)
				.ThenInclude(p => p.Usuario)
				.Include(a => a.Publicacion.Usuario)
				.Where(a => a.Publicacion.Municipio == municipio)
				.ToListAsync();

			var peticionesDto = new List<PeticionDto>(ObjectMapper.Map<List<PeticionDto>>(peticiones));


			foreach (PeticionDto peti in peticionesDto)
			{
				foreach (PublicacionGustadaDto publiGus in peti.UsuariosGustaPeticion)
				{
					if (usuarioActual.Id == publiGus.Usuario.Id)
					{
						peti.usuarioActualGustaPublicacion = true;
					}
				}

			}

			return new ListResultDto<PeticionDto>(ObjectMapper.Map<List<PeticionDto>>(peticionesDto));
		}

		public async Task<ListResultDto<PeticionDto>> BusquedaPeticionesPorCiudad(string ciudad)
		{
			var usuarioActual = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());

			var peticiones = await _peticionRepository.GetAll()
				.Include(a => a.Publicacion)
				.ThenInclude(p => p.PublicacionesGustadas)
				.ThenInclude(p => p.Usuario)
				.Include(a => a.Publicacion.Usuario)
				.Where(a => a.Publicacion.Ciudad == ciudad)
				.ToListAsync();

			var peticionesDto = new List<PeticionDto>(ObjectMapper.Map<List<PeticionDto>>(peticiones));


			foreach (PeticionDto peti in peticionesDto)
			{
				foreach (PublicacionGustadaDto publiGus in peti.UsuariosGustaPeticion)
				{
					if (usuarioActual.Id == publiGus.Usuario.Id)
					{
						peti.usuarioActualGustaPublicacion = true;
					}
				}

			}

			return new ListResultDto<PeticionDto>(ObjectMapper.Map<List<PeticionDto>>(peticionesDto));
		}

		public async Task<ListResultDto<PeticionDto>> BusquedaPeticionesPorCategoria(string categoria)
		{
			var usuarioActual = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());

			var peticiones = await _peticionRepository.GetAll()
				.Include(a => a.Publicacion)
				.ThenInclude(p => p.PublicacionesGustadas)
				.ThenInclude(p => p.Usuario)
				.Include(a => a.Publicacion.Usuario)
				.Where(a => a.Publicacion.Categoria == categoria)
				.ToListAsync();

			var peticionesDto = new List<PeticionDto>(ObjectMapper.Map<List<PeticionDto>>(peticiones));


			foreach (PeticionDto peti in peticionesDto)
			{
				foreach (PublicacionGustadaDto publiGus in peti.UsuariosGustaPeticion)
				{
					if (usuarioActual.Id == publiGus.Usuario.Id)
					{
						peti.usuarioActualGustaPublicacion = true;
					}
				}

			}

			return new ListResultDto<PeticionDto>(ObjectMapper.Map<List<PeticionDto>>(peticionesDto));
		}

		public async Task<ListResultDto<PeticionDto>> BusquedaPeticionesUrgentes(bool urgente)
		{
			var usuarioActual = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());

			var peticiones = await _peticionRepository.GetAll()
				.Include(a => a.Publicacion)
				.ThenInclude(p => p.PublicacionesGustadas)
				.ThenInclude(p => p.Usuario)
				.Include(a => a.Publicacion.Usuario)
				.Where(p => p.IsUrgent == urgente)
				.ToListAsync();

			var peticionesDto = new List<PeticionDto>(ObjectMapper.Map<List<PeticionDto>>(peticiones));


			foreach (PeticionDto peti in peticionesDto)
			{
				foreach (PublicacionGustadaDto publiGus in peti.UsuariosGustaPeticion)
				{
					if (usuarioActual.Id == publiGus.Usuario.Id)
					{
						peti.usuarioActualGustaPublicacion = true;
					}
				}

			}

			return new ListResultDto<PeticionDto>(ObjectMapper.Map<List<PeticionDto>>(peticionesDto));
		}
	}
}
