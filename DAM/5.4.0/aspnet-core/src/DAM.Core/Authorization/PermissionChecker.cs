using Abp.Authorization;
using DAM.Authorization.Roles;
using DAM.Authorization.Users;

namespace DAM.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
