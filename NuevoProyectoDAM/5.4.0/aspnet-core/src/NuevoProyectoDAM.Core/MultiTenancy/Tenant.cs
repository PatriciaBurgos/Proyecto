using Abp.MultiTenancy;
using NuevoProyectoDAM.Authorization.Users;

namespace NuevoProyectoDAM.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
