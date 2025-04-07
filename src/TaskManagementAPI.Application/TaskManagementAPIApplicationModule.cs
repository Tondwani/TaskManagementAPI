using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using TaskManagementAPI.Authorization;

namespace TaskManagementAPI;

[DependsOn(
    typeof(TaskManagementAPICoreModule),
    typeof(AbpAutoMapperModule))]
public class TaskManagementAPIApplicationModule : AbpModule
{
    public override void PreInitialize()
    {
        Configuration.Authorization.Providers.Add<TaskManagementAPIAuthorizationProvider>();
    }

    public override void Initialize()
    {
        var thisAssembly = typeof(TaskManagementAPIApplicationModule).GetAssembly();

        IocManager.RegisterAssemblyByConvention(thisAssembly);

        Configuration.Modules.AbpAutoMapper().Configurators.Add(
            // Scan the assembly for classes which inherit from AutoMapper.Profile
            cfg => cfg.AddMaps(thisAssembly)
        );
    }

    //public override void PreInitialize()
    //{
    //    Configuration.Modules.AbpAutoMapper().Configurators.Add(
    //        cfg => cfg.AddProfile<TaskManagementAPIAutoMapperProfile>()
    ////    );
    //}
}
