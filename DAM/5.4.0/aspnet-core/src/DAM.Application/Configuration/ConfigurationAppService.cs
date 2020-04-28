using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using DAM.Configuration.Dto;

namespace DAM.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : DAMAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
