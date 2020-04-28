using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using DAM.Authorization;

namespace DAM
{
    [DependsOn(
        typeof(DAMCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class DAMApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<DAMAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(DAMApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
