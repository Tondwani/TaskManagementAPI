using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace TaskManagementAPI.Controllers
{
    public abstract class TaskManagementAPIControllerBase : AbpController
    {
        protected TaskManagementAPIControllerBase()
        {
            LocalizationSourceName = TaskManagementAPIConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
