using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using DAM.Anuncios.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Anuncios
{
	public class AnuncioAppService : AsyncCrudAppService<Anuncio, AnuncioDto, int, PagedAnuncioResultRequestDto, AnuncioCreateDto, AnuncioDto>
	{
		private readonly IRepository<Anuncio> _anuncioRepository;
		public AnuncioAppService(IRepository<Anuncio> repository) : base(repository)
		{
			_anuncioRepository = repository;
		}

		public async Task<ListResultDto<AnuncioDto>> GetPublicacionesAnuncios()
		{
			var anuncios = await _anuncioRepository.GetAll()
				.Include(a => a.Publicacion).ToListAsync();
			return new ListResultDto<AnuncioDto>(ObjectMapper.Map<List<AnuncioDto>>(anuncios));
		}
	}
}
