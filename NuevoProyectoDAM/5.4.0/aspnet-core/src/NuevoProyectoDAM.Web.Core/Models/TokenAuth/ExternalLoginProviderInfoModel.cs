using Abp.AutoMapper;
using NuevoProyectoDAM.Authentication.External;

namespace NuevoProyectoDAM.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
