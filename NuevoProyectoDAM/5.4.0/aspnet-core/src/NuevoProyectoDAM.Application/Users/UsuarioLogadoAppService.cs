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

		public async Task<UserDto> GetUsuarioLogado()
		{
			var usuarioActual = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());

			var usuario = await _userRepository.GetAll()
				.Where(u => u.Id == usuarioActual.Id)
				.FirstOrDefaultAsync();

			return ObjectMapper.Map<UserDto>(usuario);
		}

		

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

		public async Task<UsuariosSeguidoresDto> GetSeguidoresUsuario(int id)
		{
			var usuarios = await _userRepository.GetAll()
				.Include(u => u.UsuariosSeguidos)
				.ThenInclude(u => u.UsuarioSeguidor)
				.Where(u => u.Id == id)
				.FirstOrDefaultAsync();

			return ObjectMapper.Map<UsuariosSeguidoresDto>(usuarios);
		}

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

		public async Task<UsuariosSeguidosDto> GetSeguidosUsuario(int id)
		{ 
			var usuarios = await _userRepository.GetAll()
				.Include(u => u.UsuariosSeguidores)
				.ThenInclude(u => u.UsuarioSeguido)
				.Where(u => u.Id == id)
				.FirstOrDefaultAsync();

			return ObjectMapper.Map<UsuariosSeguidosDto>(usuarios);
		}

		public async Task<UserDto> GetUsuarioAplicacion(int id)
		{			
			var usuario = await _userRepository.GetAll()
				.Where(u => u.Id == id)
				.FirstOrDefaultAsync();

			return ObjectMapper.Map<UserDto>(usuario);
		}

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

		public async Task<ListResultDto<UserDto>> GetAllUsuarios()
		{
			var usuarios = await _userRepository.GetAllListAsync();

			return new ListResultDto<UserDto>(ObjectMapper.Map<List<UserDto>>(usuarios));
		}

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
			user.Photo = "http://localhost:21021/Resources/ProfilePics/" + user.Id + "_profilepic.png";

			await _userRepository.UpdateAsync(user);
			await CurrentUnitOfWork.SaveChangesAsync();

			return dbPath;
		}

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

		public async Task<ListResultDto<UserDto>> BusquedaLogin(string login)
		{
			var usuarios = await _userRepository.GetAll()
				.Where(u => u.UserName == login)
				.ToListAsync();

			return new ListResultDto<UserDto>(ObjectMapper.Map<List<UserDto>>(usuarios));
		}

	}
}
