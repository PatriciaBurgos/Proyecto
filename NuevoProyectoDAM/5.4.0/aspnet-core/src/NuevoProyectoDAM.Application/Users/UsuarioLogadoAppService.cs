using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.IdentityFramework;
using Abp.Runtime.Session;
using Abp.UI;
using DAM.UsuariosGustados;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NuevoProyectoDAM.Authorization;
using NuevoProyectoDAM.Authorization.Users;
using NuevoProyectoDAM.Users.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;



namespace NuevoProyectoDAM.Users
{
	[AbpAuthorize(PermissionNames.Pages_UsersNormales)]
	public class UsuarioLogadoAppService : ApplicationService 
	{
		private readonly IRepository<User,long> _userRepository;
		private readonly UserManager _userManager;
		private readonly IAbpSession _abpSession;

		public UsuarioLogadoAppService(IRepository<User,long> repository, IAbpSession abpSession, UserManager userManager) 
		{
			_userRepository = repository;
			_userManager = userManager;
			_abpSession = abpSession;
		}

		/// <summary>
		/// Consulta de los datos personales del usuario logado
		/// </summary>
		/// <returns>Datos del usuario logado</returns>
		public async Task<UserDto> GetUsuarioLogado()
		{
			var usuarioActual = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());

			var usuario = await _userRepository.GetAll()
				.Where(u => u.Id == usuarioActual.Id)
				.FirstOrDefaultAsync();

			return ObjectMapper.Map<UserDto>(usuario);
		}

		/// <summary>
		/// Consulta de los seguidores del usuario logado
		/// </summary>
		/// <returns>Lista de usuario seguidores del usuario logado</returns>
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

		/// <summary>
		/// Consulta de los seguidores de un usuario
		/// </summary>
		/// <param name="id">Identificador del usuario</param>
		/// <returns>Lista de usuario seguidores del usuario</returns>
		public async Task<UsuariosSeguidoresDto> GetSeguidoresUsuario(int id)
		{
			var usuarios = await _userRepository.GetAll()
				.Include(u => u.UsuariosSeguidos)
				.ThenInclude(u => u.UsuarioSeguidor)
				.Where(u => u.Id == id)
				.FirstOrDefaultAsync();

			return ObjectMapper.Map<UsuariosSeguidoresDto>(usuarios);
		}

		/// <summary>
		/// Consulta de los seguidos del usuario logado
		/// </summary>
		/// <returns>Lista de usuario seguidos del usuario logado</returns>
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

		/// <summary>
		/// Consulta de los seguidos de un usuario
		/// </summary>
		/// <param name="id">Identificador del usuario</param>
		/// <returns>Lista de usuario seguidos del usuario</returns>
		public async Task<UsuariosSeguidosDto> GetSeguidosUsuario(int id)
		{ 
			var usuarios = await _userRepository.GetAll()
				.Include(u => u.UsuariosSeguidores)
				.ThenInclude(u => u.UsuarioSeguido)
				.Where(u => u.Id == id)
				.FirstOrDefaultAsync();

			return ObjectMapper.Map<UsuariosSeguidosDto>(usuarios);
		}

		/// <summary>
		/// Consulta de los datos de un usuario 
		/// </summary>
		/// <param name="id">Identificador del usuario</param>
		/// <returns>Usuario con sus datos</returns>
		public async Task<UserDto> GetUsuarioAplicacion(int id)
		{			
			var usuario = await _userRepository.GetAll()
				.Where(u => u.Id == id)
				.FirstOrDefaultAsync();

			return ObjectMapper.Map<UserDto>(usuario);
		}

		/// <summary>
		/// Consulta si el usuario logado sigue a un usuario
		/// </summary>
		/// <param name="idUser">Identificador del usuario seguido</param>
		/// <returns>True/False depende de si lo sigue o no</returns>
		public async Task<bool> SaberSiUsuarioActualEsSeguidorAsync(int idUser)
		{
			bool usSeguido = false;

			var usuarioActual = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());

			var usuarios = await _userRepository.GetAll()
				.Include(u => u.UsuariosSeguidos)
				.ThenInclude(u => u.UsuarioSeguidor)
				.Where(u => u.Id == idUser)
				.FirstOrDefaultAsync();

			foreach(UsuarioGustado us in usuarios.UsuariosSeguidos)
			{
				if(us.UsuarioSeguidorId == usuarioActual.Id)
				{
					usSeguido = true;
				}
			}

			return usSeguido;
		}

		/// <summary>
		/// Consulta de todos los usuarios de la aplicación
		/// </summary>
		/// <returns>Todos los usuarios</returns>
		public async Task<ListResultDto<UserDto>> GetAllUsuarios()
		{
			var usuarios = await _userRepository.GetAllListAsync();

			return new ListResultDto<UserDto>(ObjectMapper.Map<List<UserDto>>(usuarios));
		}

		/// <summary>
		/// Actualiza la foto del usuario logado
		/// </summary>
		/// <param name="file">Foto elegida por el usuario</param>
		/// <returns>Ruta de la foto</returns>
		public async Task<string> UploadFoto(IFormFile file)
		{
			if (file == null || file.Length == 0)
				throw new UserFriendlyException("Por favor, seleccione una fotografía");

			var folderName = Path.Combine("Resources", "ProfilePics");
			var filePath = Path.Combine(Directory.GetCurrentDirectory(), folderName);

			if (!Directory.Exists(filePath))
			{
				Directory.CreateDirectory(filePath);
			}
			long currentUserId = _abpSession.UserId.Value;

			var uniqueFileName = $"{currentUserId}_profilepic.png";
			var dbPath = Path.Combine(folderName, uniqueFileName);

			using (var fileStream = new FileStream(Path.Combine(filePath, uniqueFileName), FileMode.Create))
			{
				await file.CopyToAsync(fileStream);
			}

			var user = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());
			user.Photo = "http://192.168.1.43:21021/Resources/ProfilePics/" + user.Id + "_profilepic.png";

			await _userRepository.UpdateAsync(user);
			await CurrentUnitOfWork.SaveChangesAsync();

			return dbPath;
		}

		/// <summary>
		/// Actualiza el usuario logado
		/// </summary>
		/// <param name="input">Usuario logado con los datos actualizados</param>
		/// <returns>Datos del usuario logado</returns>
		public async Task<UserDto> UpdateAsync(UserDto input)
		{
			//CheckUpdatePermission();

			var user = await _userManager.GetUserByIdAsync(input.Id);

			MapToEntity(input, user);

			CheckErrors(await _userManager.UpdateAsync(user));

			return input;
		}

		protected void MapToEntity(UserDto input, User user)
		{
			ObjectMapper.Map(input, user);
			user.SetNormalizedNames();
		}

		protected virtual void CheckErrors(IdentityResult identityResult)
		{
			identityResult.CheckErrors(LocalizationManager);
		}

		/// <summary>
		/// Envia un correo electrónico a un usuario
		/// </summary>
		/// <param name="emisor">Correo del usuario logado</param>
		/// <param name="password">Contraseña del correo del usuario logado</param>
		/// <param name="receptor">Correo del usuario al que se le va a mandar el mensaje</param>
		/// <param name="asunto">Asunto del mensaje</param>
		/// <param name="texto">Texto del mensaje a enviar</param>
		/// <returns>Confimación de que se ha mandado el mensaje</returns>
		public async Task<bool> EnviarCorreo(string emisor, string password, string receptor, string asunto, string texto)
		{

			var client = new SmtpClient("smtp.gmail.com", 587)
			{
				Credentials = new NetworkCredential(emisor, password),
				EnableSsl = true
			};
			client.Send(emisor, receptor, asunto, texto);
			Console.WriteLine("Sent");
			

			return true;
		}

		/// <summary>
		/// Busqueda por nombre de usuario de los usuarios
		/// </summary>
		/// <param name="login">Nombre de usuario del usuario buscado</param>
		/// <returns>Usuario encontrado</returns>
		public async Task<ListResultDto<UserDto>> BusquedaLogin(string login)
		{
			var usuarios = await _userRepository.GetAll()
				.Where(u => u.UserName == login)
				.ToListAsync();

			return new ListResultDto<UserDto>(ObjectMapper.Map<List<UserDto>>(usuarios));
		}

	}
}
