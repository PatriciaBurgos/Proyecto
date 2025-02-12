﻿using Abp.Application.Services.Dto;
using DAM.Publicaciones.Dto;
using DAM.PublicacionesGustadas.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.Anuncios.Dto
{
	public class AnuncioDto : EntityDto
	{
        public string PublicacionCategoria { get; set; }
        public string PublicacionTexto { get; set; }
        public double? PublicacionHorarioInicio { get; set; }
        public double? PublicacionHorarioFin { get; set; }
        public string PublicacionMunicipio { get; set; }
        public string PublicacionCiudad { get; set; }

        public string PublicacionId { get; set; }
        public ICollection<PublicacionGustadaDto> UsuariosGustaAnuncio { get; set; }

        public bool usuarioActualGustaPublicacion { get; set; }

        public int NumUsuarios { get; set; }

        public string PublicacionNombreUsuario { get; set; }

        public int UsuarioId { get; set; }

        public string PublicacionFoto { get; set; }

        public string Preferencias { get; set; }
	}
}
