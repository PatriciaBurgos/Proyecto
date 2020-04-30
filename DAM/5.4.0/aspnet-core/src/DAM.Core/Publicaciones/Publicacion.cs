using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAM.Publicaciones
{
	public class Publicacion : FullAuditedEntity
    {
        [Required]
        public string Categoria { get; set; }
        [Required]
        public string Texto { get; set; }
        public double? HorarioInicio { get; set; }
        public double? HorarioFin { get; set; }
        public string Municipio { get; set; }
        [Required]
        public string Ciudad { get; set; }
    }
}
