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

		/// <summary>
		/// Creación de una petición
		/// </summary>
		/// <param name="input">Datos de la nueva petición</param>
		/// <returns>Objeto petición creada</returns>
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

		/// <summary>
		/// Consulta de todas las peticiones
		/// </summary>
		/// <returns>Lista de todas las peticiones creadas</returns>
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

		/// <summary>
		/// Consulta de una petición
		/// </summary>
		/// <param name="id">Id de la petición a consultar</param>
		/// <returns>Objeto petición encontrado</returns>
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

		/// <summary>
		/// Consulta de los usuarios que les gusta una petición
		/// </summary>
		/// <param name="id">Id de la petición a consultar</param>
		/// <returns>Todos los usuarios a los que les gusta la petición</returns>
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

		/// <summary>
		/// Consulta de todas las peticiones publicadas de un usuario
		/// </summary>
		/// <param name="id">Identificador del usuario</param>
		/// <returns>Lista de todas las peticiones del usuario</returns>
		public async Task<ListResultDto<PeticionDto>> GetPeticionesUnUsuario(int id)
		{
			var peticiones = await _peticionRepository.GetAll()
				.Include(a => a.Publicacion)
				.ThenInclude(p => p.Usuario)
				.Where(a => a.Publicacion.Usuario.Id == id)
				.ToListAsync();

			return new ListResultDto<PeticionDto>(ObjectMapper.Map<List<PeticionDto>>(peticiones));
		}

		/// <summary>
		/// Consulta de todas las peticiones publicadas por el usuario logado
		/// </summary>
		/// <returns>Lista de todas las peticiones del usuario logado</returns>
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

		/// <summary>
		/// Busqueda de todas las peticiones que tengan el municipio del parametro
		/// </summary>
		/// <param name="municipio">Nombre del municipio</param>
		/// <returns>Lista de las peticiones con ese municipio</returns>
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

		/// <summary>
		/// Busqueda de todas las peticiones que tengan la ciudad del parámetro
		/// </summary>
		/// <param name="ciudad">Nombre de la ciudad</param>
		/// <returns>Lista de las peticiones con esa ciudad</returns>
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

		/// <summary>
		/// Busqueda de peticiones por una categoría concreta
		/// </summary>
		/// <param name="categoria">Nombre de la categoría</param>
		/// <returns>Lista de las peticiones con esa categoría</returns>
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

		/// <summary>
		/// Busqueda de peticiones urgentes o no
		/// </summary>
		/// <param name="urgente">True o False según si el usuario quiere buscar peticiones urgentes o no</param>
		/// <returns>Lista de las peticiones con esa urgencia</returns>
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

		/// <summary>
		/// Busqueda de peticiones por el horario de inicio 
		/// </summary>
		/// <param name="horIni">Hora de inicio de la petición</param>
		/// <returns>Lista de las peticiones con ese horario de inicio</returns>
		public async Task<ListResultDto<PeticionDto>> BusquedaPeticionesHorarioInicio(double horIni)
		{
			var usuarioActual = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());

			var peticiones = await _peticionRepository.GetAll()
				.Include(a => a.Publicacion)
				.ThenInclude(p => p.PublicacionesGustadas)
				.ThenInclude(p => p.Usuario)
				.Include(a => a.Publicacion.Usuario)
				.Where(p => p.Publicacion.HorarioInicio == horIni)
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

		/// <summary>
		/// Busqueda de peticiones por el usuario que los ha creado
		/// </summary>
		/// <param name="userNam">Nombre de usuario del creador de las peticiones</param>
		/// <returns>Lista de las peticiones de ese usuario</returns>
		public async Task<ListResultDto<PeticionDto>> BusquedaPeticionesPorUsuario(string userNam)
		{
			var usuarioActual = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());

			var peticiones = await _peticionRepository.GetAll()
				.Include(a => a.Publicacion)
				.ThenInclude(p => p.PublicacionesGustadas)
				.ThenInclude(p => p.Usuario)
				.Include(a => a.Publicacion.Usuario)
				.Where(p => p.Publicacion.Usuario.UserName == userNam)
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
