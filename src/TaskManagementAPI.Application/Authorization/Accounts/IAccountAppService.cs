using Abp.Application.Services;
using TaskManagementAPI.Authorization.Accounts.Dto;
using System.Threading.Tasks;

namespace TaskManagementAPI.Authorization.Accounts;

public interface IAccountAppService : IApplicationService
{
    Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

    Task<RegisterOutput> Register(RegisterInput input);
}
