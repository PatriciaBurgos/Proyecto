using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.Publicaciones.Dto
{
	public class PublicacionCreateDto : EntityDto
	{
        public string Categoria { get; set; }
        public string Texto { get; set; }
        public double? HorarioInicio { get; set; }
        public double? HorarioFin { get; set; }
        public string Municipio { get; set; }
        public string Ciudad { get; set; }

        public int UsuarioId { get; set; }
    }
}


