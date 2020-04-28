using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using DAM.Configuration;
using DAM.Web;

namespace DAM.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class DAMDbContextFactory : IDesignTimeDbContextFactory<DAMDbContext>
    {
        public DAMDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<DAMDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            DAMDbContextConfigurer.Configure(builder, configuration.GetConnectionString(DAMConsts.ConnectionStringName));

            return new DAMDbContext(builder.Options);
        }
    }
}
