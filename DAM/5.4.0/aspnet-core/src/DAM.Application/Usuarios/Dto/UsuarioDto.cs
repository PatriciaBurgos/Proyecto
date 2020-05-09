using Abp.Application.Services.Dto;
using DAM.Aplicaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAM.Usuarios.Dto
{
	public class UsuarioDto : EntityDto
	{
        [Required]
        public string NombreUsuario { get; set; }
        [Required]
        [MinLength(4)]
        public string Password { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime? FechaNac { get; set; }
        public string Municipio { get; set; }

        public int AplicacionId { get; set; }
    }
}
