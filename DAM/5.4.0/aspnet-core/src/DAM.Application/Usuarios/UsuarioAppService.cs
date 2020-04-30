using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using DAM.Authorization;
using DAM.Usuarios.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Usuarios
{
	[AbpAuthorize(PermissionNames.Pages_Usuarios)]
	public class UsuarioAppService : AsyncCrudAppService<Usuario, UsuarioDto, int, PagedUsuarioResultRequestDto, UsuarioDto, UsuarioDto>
	{
		private readonly IRepository<Usuario> _usuarioRepository;
		public UsuarioAppService(IRepository<Usuario> repository) : base(repository)
		{
			_usuarioRepository = repository;
		}

		public async Task<ListResultDto<UsuarioDto>> GetNombreUsuario()
		{
			var usuarios = await _usuarioRepository.GetAllListAsync();
			return new ListResultDto<UsuarioDto>(ObjectMapper.Map<List<UsuarioDto>>(usuarios));
		}

		public async Task<ListResultDto<UsuarioAplicacionDto>> GetUsuariosAplicacion()
		{
			var usuarios = await _usuarioRepository.GetAll()
				.Include(a => a.Aplicacion).ToListAsync();
			return new ListResultDto<UsuarioAplicacionDto>(ObjectMapper.Map<List<UsuarioAplicacionDto>>(usuarios));
		}
	}
}
