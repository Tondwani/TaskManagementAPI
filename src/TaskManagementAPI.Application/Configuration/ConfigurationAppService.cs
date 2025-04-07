using Abp.Authorization;
using Abp.Runtime.Session;
using TaskManagementAPI.Configuration.Dto;
using System.Threading.Tasks;

namespace TaskManagementAPI.Configuration;

[AbpAuthorize]
public class ConfigurationAppService : TaskManagementAPIAppServiceBase, IConfigurationAppService
{
    public async Task ChangeUiTheme(ChangeUiThemeInput input)
    {
        await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
    }
}
