using Abp.Modules;
using Abp.Reflection.Extensions;
using TaskManagementAPI.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace TaskManagementAPI.Web.Host.Startup
{
    [DependsOn(
       typeof(TaskManagementAPIWebCoreModule))]
    public class TaskManagementAPIWebHostModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public TaskManagementAPIWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TaskManagementAPIWebHostModule).GetAssembly());
        }
    }
}
