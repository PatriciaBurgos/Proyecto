using Abp.Domain.Entities.Auditing;
using DAM.Anuncios;
//using DAM.Aplicaciones;
using DAM.Authorization.Users;
using DAM.Peticiones;
using DAM.PublicacionesGustadas;
//using DAM.Usuarios;
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

        [Required]
        public int UsuarioId { get; set; }
        public User Usuario { get; set; }

        public ICollection<PublicacionGustada> PublicacionesGustadas { get; set; }

        //public ICollection<Anuncio> Anuncios { get; set; }  //Esto deberia estar aqui? El vector de anuncios en publicacion
        //public ICollection<Peticion> Peticiones { get; set; }
    }
}
