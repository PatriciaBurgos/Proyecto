using Abp.Application.Services;
using NuevoProyectoDAM.MultiTenancy.Dto;

namespace NuevoProyectoDAM.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

