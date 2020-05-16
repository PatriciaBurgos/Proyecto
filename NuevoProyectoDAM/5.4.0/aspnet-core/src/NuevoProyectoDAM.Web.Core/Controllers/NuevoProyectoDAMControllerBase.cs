using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace NuevoProyectoDAM.Controllers
{
    public abstract class NuevoProyectoDAMControllerBase: AbpController
    {
        protected NuevoProyectoDAMControllerBase()
        {
            LocalizationSourceName = NuevoProyectoDAMConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
