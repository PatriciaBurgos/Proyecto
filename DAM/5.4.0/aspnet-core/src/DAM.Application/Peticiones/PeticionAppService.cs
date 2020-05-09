using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using DAM.Peticiones.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Peticiones
{
	public class PeticionAppService : AsyncCrudAppService<Peticion, PeticionDto, int, PagedPeticionResultRequestDto, PeticionCreateDto, PeticionDto>
	{
		private readonly IRepository<Peticion> _peticionRepository;
		public PeticionAppService(IRepository<Peticion> repository) : base(repository)
		{
			_peticionRepository = repository;
		}

		public async Task<ListResultDto<PeticionDto>> GetPublicacionesPeticiones()
		{
			var peticiones = await _peticionRepository.GetAll()
				.Include(a => a.Publicacion).ToListAsync();
			return new ListResultDto<PeticionDto>(ObjectMapper.Map<List<PeticionDto>>(peticiones));
		}
	}
}
