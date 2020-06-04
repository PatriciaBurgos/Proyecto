using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace NuevoProyectoDAM.Authorization
{
    public class NuevoProyectoDAMAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_UsersNormales, L("UsersNormales"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
            context.CreatePermission(PermissionNames.Pages_Anuncios, L("Anuncios"));
            context.CreatePermission(PermissionNames.Pages_Peticiones, L("Peticiones"));
            context.CreatePermission(PermissionNames.Pages_Publicaciones, L("Publicaciones"));
            context.CreatePermission(PermissionNames.Pages_Chats, L("Chats"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, NuevoProyectoDAMConsts.LocalizationSourceName);
        }
    }
}
