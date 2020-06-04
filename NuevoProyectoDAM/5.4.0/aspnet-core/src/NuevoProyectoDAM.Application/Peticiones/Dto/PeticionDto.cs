using Abp.Application.Services.Dto;
using DAM.Publicaciones.Dto;
using DAM.PublicacionesGustadas.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.Peticiones.Dto
{
	public class PeticionDto : EntityDto
	{
        public string PublicacionCategoria { get; set; }
        public string PublicacionTexto { get; set; }
        public double? PublicacionHorarioInicio { get; set; }
        public double? PublicacionHorarioFin { get; set; }
        public string PublicacionMunicipio { get; set; }
        public string PublicacionCiudad { get; set; }

        public string PublicacionId { get; set; }

        public ICollection<PublicacionGustadaDto> UsuariosGustaPeticion { get; set; }
        public int NumUsuarios { get; set; }

        public string PublicacionNombreUsuario { get; set; }

        public bool IsUrgent { get; set; }


	}
}
