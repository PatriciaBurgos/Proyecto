using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using NuevoProyectoDAM.Configuration;
using NuevoProyectoDAM.EntityFrameworkCore;
using NuevoProyectoDAM.Migrator.DependencyInjection;

namespace NuevoProyectoDAM.Migrator
{
    [DependsOn(typeof(NuevoProyectoDAMEntityFrameworkModule))]
    public class NuevoProyectoDAMMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public NuevoProyectoDAMMigratorModule(NuevoProyectoDAMEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(NuevoProyectoDAMMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                NuevoProyectoDAMConsts.ConnectionStringName
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
            IocManager.RegisterAssemblyByConvention(typeof(NuevoProyectoDAMMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
