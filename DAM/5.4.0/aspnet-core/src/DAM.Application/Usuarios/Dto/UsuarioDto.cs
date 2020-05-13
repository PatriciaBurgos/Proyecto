using Abp.Application.Services.Dto;
using DAM.Aplicaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAM.Usuarios.Dto
{
	public class UsuarioDto : EntityDto //Todos los datos
	{        
        public string NombreUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime? FechaNac { get; set; }
        public string Municipio { get; set; }
        public string Ciudad { get; set; }
        public string Correo { get; set; }
        public string Cualidades { get; set; }
        public string RutaFoto { get; set; }

        public int AplicacionId { get; set; }

        //public ICollection<Chat> ChatsUsuarioOrigen { get; set; } //lo que mando
        //public ICollection<Chat> ChatsUsuarioDestino { get; set; } //lo que recibo
        //public ICollection<Publicacion> Publicaciones { get; set; }
        //public ICollection<PublicacionGustada> PublicacionesGustadas { get; set; }
        //public ICollection<UsuarioGustado> UsuariosSeguidores { get; set; } //los me siguen
        //public ICollection<UsuarioGustado> UsuariosSeguidos { get; set; } //los que sigo
    }
}
