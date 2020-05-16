using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using NuevoProyectoDAM.Configuration;

namespace NuevoProyectoDAM.Web.Host.Startup
{
    [DependsOn(
       typeof(NuevoProyectoDAMWebCoreModule))]
    public class NuevoProyectoDAMWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public NuevoProyectoDAMWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(NuevoProyectoDAMWebHostModule).GetAssembly());
        }
    }
}
