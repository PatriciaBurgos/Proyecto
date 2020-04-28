using System.Threading.Tasks;
using DAM.Configuration.Dto;

namespace DAM.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
