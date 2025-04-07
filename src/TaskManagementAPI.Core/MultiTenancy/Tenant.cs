using Abp.MultiTenancy;
using TaskManagementAPI.Authorization.Users;

namespace TaskManagementAPI.MultiTenancy;

public class Tenant : AbpTenant<User>
{
    public Tenant()
    {
    }

    public Tenant(string tenancyName, string name)
        : base(tenancyName, name)
    {
    }
}
