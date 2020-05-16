using System.Threading.Tasks;
using Abp.Application.Services;
using NuevoProyectoDAM.Sessions.Dto;

namespace NuevoProyectoDAM.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
