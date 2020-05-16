using System.ComponentModel.DataAnnotations;

namespace NuevoProyectoDAM.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}