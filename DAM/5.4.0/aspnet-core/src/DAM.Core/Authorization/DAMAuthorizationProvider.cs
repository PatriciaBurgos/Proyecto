using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace DAM.Authorization
{
    public class DAMAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
            context.CreatePermission(PermissionNames.Pages_Aplicaciones, L("Aplicaciones"));
            context.CreatePermission(PermissionNames.Pages_Usuarios, L("Usuarios"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, DAMConsts.LocalizationSourceName);
        }
    }
}
