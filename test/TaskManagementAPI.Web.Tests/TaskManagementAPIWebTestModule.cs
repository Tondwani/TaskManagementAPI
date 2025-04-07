using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using TaskManagementAPI.EntityFrameworkCore;
using TaskManagementAPI.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace TaskManagementAPI.Web.Tests;

[DependsOn(
    typeof(TaskManagementAPIWebMvcModule),
    typeof(AbpAspNetCoreTestBaseModule)
)]
public class TaskManagementAPIWebTestModule : AbpModule
{
    public TaskManagementAPIWebTestModule(TaskManagementAPIEntityFrameworkModule abpProjectNameEntityFrameworkModule)
    {
        abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
    }

    public override void PreInitialize()
    {
        Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
    }

    public override void Initialize()
    {
        IocManager.RegisterAssemblyByConvention(typeof(TaskManagementAPIWebTestModule).GetAssembly());
    }

    public override void PostInitialize()
    {
        IocManager.Resolve<ApplicationPartManager>()
            .AddApplicationPartsIfNotAddedBefore(typeof(TaskManagementAPIWebMvcModule).Assembly);
    }
}