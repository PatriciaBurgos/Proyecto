using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using DAM.Aplicaciones.Dto;
using DAM.Authorization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Aplicaciones
{
	[AbpAuthorize(PermissionNames.Pages_Aplicaciones)]
	public class AplicacionAppService : AsyncCrudAppService<Aplicacion, AplicacionDto, int, PagedAplicacionResultRequestDto, AplicacionDto, AplicacionDto>
	{
		private readonly IRepository<Aplicacion> _aplicacionRepository;
		public AplicacionAppService(IRepository<Aplicacion> repository) : base(repository)
		{
			_aplicacionRepository = repository;
		}

		public async Task<ListResultDto<AplicacionDto>> GetNombreAplicacion()
		{
			var aplicaciones = await _aplicacionRepository.GetAllListAsync();
			return new ListResultDto<AplicacionDto>(ObjectMapper.Map<List<AplicacionDto>>(aplicaciones));
		}

		public async Task<ListResultDto<AplicacionConVectorUsuariosDto>> GetVectorUsuarios()
		{
			var usuarios = await _aplicacionRepository.GetAllListAsync();
				//.Include(a => a.Usuario).ToListAsync();
			return new ListResultDto<AplicacionConVectorUsuariosDto>(ObjectMapper.Map<List<AplicacionConVectorUsuariosDto>>(usuarios));
		}
	}
}