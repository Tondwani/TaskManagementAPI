using Abp.Application.Services;
using TaskManagementAPI.MultiTenancy.Dto;

namespace TaskManagementAPI.MultiTenancy;

public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
{
}

