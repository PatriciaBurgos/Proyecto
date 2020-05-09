using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using DAM.Aplicaciones.Dto;
using DAM.Authorization;
using DAM.Authorization.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Aplicaciones
{
	[AbpAuthorize(PermissionNames.Pages_Aplicaciones)]
	public class AplicacionAppService : AsyncCrudAppService<Aplicacion, AplicacionDto, int, PagedAplicacionResultRequestDto, AplicacionDto, AplicacionDto>
	{
		private readonly IRepository<Aplicacion> _aplicacionRepository;
		private readonly UserManager _userManager;

		public AplicacionAppService(IRepository<Aplicacion> repository, UserManager userManager) : base(repository)
		{
			_aplicacionRepository = repository;
			_userManager = userManager;
		}

		protected override async Task<AplicacionDto> UpdateAsync(AplicacionDto input)
		{
			CheckUpdatePermission();
			var aplicacionActual = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());

			var apl = _aplicacionRepository
				.GetAll()
				.Where(apl => apl.Id == input.Id)
				.FirstOrDefaultAsync();

			apl = ObjectMapper.Map<Aplicacion>(input);

			await _aplicacionRepository.UpdateAsync(apl);

			return ObjectMapper.Map<AplicacionDto>(apl);
		}

		public async Task<ListResultDto<AplicacionDto>> GetNombreAplicacion()
		{
			var aplicaciones = await _aplicacionRepository.GetAllListAsync();
			return new ListResultDto<AplicacionDto>(ObjectMapper.Map<List<AplicacionDto>>(aplicaciones));
		}

		public async Task<ListResultDto<AplicacionConVectorUsuariosPublicacionesDto>> GetVectorUsuariosPublicaciones(int id)
		{
			var usuariosPublicaciones = await _aplicacionRepository.GetAll()
				.Include(a => a.Usuarios)
				.Include(a => a.Publicaciones)
				.Where(a => a.Id == id)
				.ToListAsync();

			return new ListResultDto<AplicacionConVectorUsuariosPublicacionesDto>(ObjectMapper.Map<List<AplicacionConVectorUsuariosPublicacionesDto>>(usuariosPublicaciones));
		}

		//Metodo numero usuarios
		//Metodo numero publicaciones

		
	}
}