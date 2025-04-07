using TaskManagementAPI.Configuration.Dto;
using System.Threading.Tasks;

namespace TaskManagementAPI.Configuration;

public interface IConfigurationAppService
{
    Task ChangeUiTheme(ChangeUiThemeInput input);
}
