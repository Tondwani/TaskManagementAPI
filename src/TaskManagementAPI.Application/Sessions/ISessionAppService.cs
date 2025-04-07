using Abp.Application.Services;
using TaskManagementAPI.Sessions.Dto;
using System.Threading.Tasks;

namespace TaskManagementAPI.Sessions;

public interface ISessionAppService : IApplicationService
{
    Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
}
