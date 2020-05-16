using System.Threading.Tasks;
using Abp.Application.Services;
using NuevoProyectoDAM.Authorization.Accounts.Dto;

namespace NuevoProyectoDAM.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
