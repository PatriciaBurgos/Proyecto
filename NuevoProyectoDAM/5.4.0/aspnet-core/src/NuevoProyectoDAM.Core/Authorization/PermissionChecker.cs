using Abp.Authorization;
using NuevoProyectoDAM.Authorization.Roles;
using NuevoProyectoDAM.Authorization.Users;

namespace NuevoProyectoDAM.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
