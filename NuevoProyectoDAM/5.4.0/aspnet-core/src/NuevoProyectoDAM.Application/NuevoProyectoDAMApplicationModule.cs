using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using NuevoProyectoDAM.Authorization;

namespace NuevoProyectoDAM
{
    [DependsOn(
        typeof(NuevoProyectoDAMCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class NuevoProyectoDAMApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<NuevoProyectoDAMAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(NuevoProyectoDAMApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
