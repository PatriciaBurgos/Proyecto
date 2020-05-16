using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using NuevoProyectoDAM.Configuration.Dto;

namespace NuevoProyectoDAM.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : NuevoProyectoDAMAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
