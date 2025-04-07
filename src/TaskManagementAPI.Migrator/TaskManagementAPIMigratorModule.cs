using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using TaskManagementAPI.Configuration;
using TaskManagementAPI.EntityFrameworkCore;
using TaskManagementAPI.Migrator.DependencyInjection;
using Castle.MicroKernel.Registration;
using Microsoft.Extensions.Configuration;

namespace TaskManagementAPI.Migrator;

[DependsOn(typeof(TaskManagementAPIEntityFrameworkModule))]
public class TaskManagementAPIMigratorModule : AbpModule
{
    private readonly IConfigurationRoot _appConfiguration;

    public TaskManagementAPIMigratorModule(TaskManagementAPIEntityFrameworkModule abpProjectNameEntityFrameworkModule)
    {
        abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

        _appConfiguration = AppConfigurations.Get(
            typeof(TaskManagementAPIMigratorModule).GetAssembly().GetDirectoryPathOrNull()
        );
    }

    public override void PreInitialize()
    {
        Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
            TaskManagementAPIConsts.ConnectionStringName
        );

        Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        Configuration.ReplaceService(
            typeof(IEventBus),
            () => IocManager.IocContainer.Register(
                Component.For<IEventBus>().Instance(NullEventBus.Instance)
            )
        );
    }

    public override void Initialize()
    {
        IocManager.RegisterAssemblyByConvention(typeof(TaskManagementAPIMigratorModule).GetAssembly());
        ServiceCollectionRegistrar.Register(IocManager);
    }
}
