using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAM.Usuarios
{
	public class Usuario : FullAuditedEntity
	{
        [Required][MaxLength(30)]
        public string NombreUsuario { get; set; }
        [Required][MinLength(4)]
        public string Password { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime? FechaNac { get; set; }
        public string Municipio { get; set; }
        public string Ciudad { get; set; }
        public string Correo { get; set; }
        public string Cualidades { get; set; }
        public string RutaFoto { get; set; }
    }
}
