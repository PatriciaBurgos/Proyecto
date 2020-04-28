using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace DAM.Controllers
{
    public abstract class DAMControllerBase: AbpController
    {
        protected DAMControllerBase()
        {
            LocalizationSourceName = DAMConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
