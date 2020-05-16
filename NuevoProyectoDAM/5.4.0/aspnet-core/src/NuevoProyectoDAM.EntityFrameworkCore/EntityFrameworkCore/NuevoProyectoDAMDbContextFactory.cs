using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using NuevoProyectoDAM.Configuration;
using NuevoProyectoDAM.Web;

namespace NuevoProyectoDAM.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class NuevoProyectoDAMDbContextFactory : IDesignTimeDbContextFactory<NuevoProyectoDAMDbContext>
    {
        public NuevoProyectoDAMDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<NuevoProyectoDAMDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            NuevoProyectoDAMDbContextConfigurer.Configure(builder, configuration.GetConnectionString(NuevoProyectoDAMConsts.ConnectionStringName));

            return new NuevoProyectoDAMDbContext(builder.Options);
        }
    }
}
