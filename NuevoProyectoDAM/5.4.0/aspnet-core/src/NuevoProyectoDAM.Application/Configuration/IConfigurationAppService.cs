using System.Threading.Tasks;
using NuevoProyectoDAM.Configuration.Dto;

namespace NuevoProyectoDAM.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
