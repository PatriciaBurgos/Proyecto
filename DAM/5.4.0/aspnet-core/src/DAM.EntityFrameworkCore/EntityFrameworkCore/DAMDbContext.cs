using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using DAM.Authorization.Roles;
using DAM.Authorization.Users;
using DAM.MultiTenancy;
using DAM.Aplicaciones;

namespace DAM.EntityFrameworkCore
{
    public class DAMDbContext : AbpZeroDbContext<Tenant, Role, User, DAMDbContext>
    {
        /* Define a DbSet for each entity of the application */

        public DAMDbContext(DbContextOptions<DAMDbContext> options)
            : base(options)
        {
        }
        public DbSet<Aplicacion>Aplicacion {get;set;}        
    }
}
