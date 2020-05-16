using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace NuevoProyectoDAM.EntityFrameworkCore
{
    public static class NuevoProyectoDAMDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<NuevoProyectoDAMDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<NuevoProyectoDAMDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
