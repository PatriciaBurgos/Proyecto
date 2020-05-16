using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using NuevoProyectoDAM.EntityFrameworkCore.Seed;

namespace NuevoProyectoDAM.EntityFrameworkCore
{
    [DependsOn(
        typeof(NuevoProyectoDAMCoreModule), 
        typeof(AbpZeroCoreEntityFrameworkCoreModule))]
    public class NuevoProyectoDAMEntityFrameworkModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<NuevoProyectoDAMDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        NuevoProyectoDAMDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        NuevoProyectoDAMDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(NuevoProyectoDAMEntityFrameworkModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            if (!SkipDbSeed)
            {
                SeedHelper.SeedHostDb(IocManager);
            }
        }
    }
}
