using System.Threading.Tasks;
using Abp.Application.Services;
using DAM.Sessions.Dto;

namespace DAM.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
