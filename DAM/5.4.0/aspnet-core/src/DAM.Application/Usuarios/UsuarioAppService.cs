using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using DAM.Authorization;
using DAM.Authorization.Users;
using DAM.Usuarios.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Linq;

namespace DAM.Usuarios
{
	[AbpAuthorize(PermissionNames.Pages_Usuarios)]
	public class UsuarioAppService : AsyncCrudAppService<Usuario, UsuarioDto, int, PagedUsuarioResultRequestDto, UsuarioDto, UsuarioDto>
	{
		private readonly IRepository<Usuario> _usuarioRepository;
		private readonly UserManager _userManager;
		public UsuarioAppService(IRepository<Usuario> repository, UserManager userManager) : base(repository)
		{
			_usuarioRepository = repository;
			_userManager = userManager;
		}

		public async Task<ListResultDto<UsuarioDto>> GetDatosUsuarios()
		{
			var usuarios = await _usuarioRepository.GetAll()
				.Include(u => u.Aplicacion)
				.ToListAsync();

			return new ListResultDto<UsuarioDto>(ObjectMapper.Map<List<UsuarioDto>>(usuarios));
		}

		public async Task<ListResultDto<UsuarioDto>> GetDatosUnUsuario(int id)
		{
			var usuarios = await _usuarioRepository.GetAll()
				.Include(a => a.Aplicacion)
				.Where(a => a.Id == id)
				.ToListAsync();

			return new ListResultDto<UsuarioDto>(ObjectMapper.Map<List<UsuarioDto>>(usuarios));
		}

		public async Task<ListResultDto<UsuarioAplicacionDto>> GetUsuariosConIdAplicacion()
		{
			var usuarios = await _usuarioRepository.GetAll()
				.Include(a => a.Aplicacion).ToListAsync();
			return new ListResultDto<UsuarioAplicacionDto>(ObjectMapper.Map<List<UsuarioAplicacionDto>>(usuarios));
		}
	}
}
