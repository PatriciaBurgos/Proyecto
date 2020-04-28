using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace DAM.EntityFrameworkCore
{
    public static class DAMDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<DAMDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<DAMDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
