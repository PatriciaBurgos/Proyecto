using Abp.Application.Services;
using DAM.MultiTenancy.Dto;

namespace DAM.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

