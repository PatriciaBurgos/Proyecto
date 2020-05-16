using Abp.Application.Services.Dto;

namespace NuevoProyectoDAM.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

