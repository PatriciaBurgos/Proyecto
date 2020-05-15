using Abp.Application.Services.Dto;
using DAM.Aplicaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAM.Usuarios.Dto
{
	public class UsuarioAplicacionDto : EntityDto
    {
        public int AplicacionId { get; set; }
        public string AplicacionNombre { get; set; }

        public string NombreUsuario { get; set; }
    }
}
