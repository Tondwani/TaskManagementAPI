using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace TaskManagementAPI.Authorization;

public class TaskManagementAPIAuthorizationProvider : AuthorizationProvider
{
    public override void SetPermissions(IPermissionDefinitionContext context)
    {
        context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
        context.CreatePermission(PermissionNames.Pages_Users_Activation, L("UsersActivation"));
        context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
        context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);

        // ✅ Duty permissions
        var duty = context.CreatePermission("Duty", L("Duty"));
        duty.CreateChildPermission("Duty.Create", L("CreateDuty"));
        duty.CreateChildPermission("Duty.Update", L("UpdateDuty")); 
        duty.CreateChildPermission("Duty.Delete", L("DeleteDuty"));
        duty.CreateChildPermission("Duty.View", L("ViewDuty"));
        duty.CreateChildPermission("Duty.Assign", L("AssignDuty")); 
    }

    private static ILocalizableString L(string name)
    {
        return new LocalizableString(name, TaskManagementAPIConsts.LocalizationSourceName);
    }
}
