using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.Publicaciones.Dto
{
	public class PublicacionReducidaDto : EntityDto
    {
        public string Categoria { get; set; }
        public string Texto { get; set; }
        public string Ciudad { get; set; }
    }
}
