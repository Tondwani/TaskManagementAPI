using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using TaskManagementAPI.EntityFrameworkCore.Seed;

namespace TaskManagementAPI.EntityFrameworkCore;

[DependsOn(
    typeof(TaskManagementAPICoreModule),
    typeof(AbpZeroCoreEntityFrameworkCoreModule))]
public class TaskManagementAPIEntityFrameworkModule : AbpModule
{
    /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
    public bool SkipDbContextRegistration { get; set; }

    public bool SkipDbSeed { get; set; }

    public override void PreInitialize()
    {
        if (!SkipDbContextRegistration)
        {
            Configuration.Modules.AbpEfCore().AddDbContext<TaskManagementAPIDbContext>(options =>
            {
                if (options.ExistingConnection != null)
                {
                    TaskManagementAPIDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                }
                else
                {
                    TaskManagementAPIDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                }
            });
        }
    }

    public override void Initialize()
    {
        IocManager.RegisterAssemblyByConvention(typeof(TaskManagementAPIEntityFrameworkModule).GetAssembly());
    }

    public override void PostInitialize()
    {
        if (!SkipDbSeed)
        {
            SeedHelper.SeedHostDb(IocManager);
        }
    }
}
