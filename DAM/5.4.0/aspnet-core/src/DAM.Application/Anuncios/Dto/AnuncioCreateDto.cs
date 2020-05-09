using Abp.Application.Services.Dto;
using DAM.Publicaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAM.Anuncios.Dto
{
	public class AnuncioCreateDto : EntityDto
	{
        public Publicacion Publicacion { get; set; }

        public string Preferencias { get; set; }
    }
}
