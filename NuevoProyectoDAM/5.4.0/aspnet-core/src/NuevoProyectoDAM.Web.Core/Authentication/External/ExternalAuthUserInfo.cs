using System;
using System.ComponentModel.DataAnnotations;

namespace NuevoProyectoDAM.Authentication.External
{
    public class ExternalAuthUserInfo
    {
        public string ProviderKey { get; set; }

        public string Name { get; set; }

        public string EmailAddress { get; set; }

        public string Surname { get; set; }

        public string Provider { get; set; }

        public DateTime BirthDate { get; set; }
        [MaxLength(50)]
        public String Town { get; set; }
        [MaxLength(50)]
        public String City { get; set; }
        [MaxLength(256)]
        public String Qualities { get; set; }
    }
}
