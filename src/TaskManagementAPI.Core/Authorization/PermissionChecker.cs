 using Abp.Authorization;
using TaskManagementAPI.Authorization.Roles;
using TaskManagementAPI.Authorization.Users;

namespace TaskManagementAPI.Authorization;

public class PermissionChecker : PermissionChecker<Role, User>
{
    public PermissionChecker(UserManager userManager)
        : base(userManager)
    {
    }
}
