using Abp.Domain.Entities.Auditing;
using DAM.Aplicaciones;
using DAM.Chats;
using DAM.Publicaciones;
using DAM.PublicacionesGustadas;
using DAM.UsuariosGustados;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAM.Usuarios
{
	public class Usuario : FullAuditedEntity
	{

        [Required][MaxLength(30)]
        public string NombreUsuario { get; set; }
        [Required][MinLength(4)]
        public string Password { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime? FechaNac { get; set; }
        public string Municipio { get; set; }
        public string Ciudad { get; set; }
        public string Correo { get; set; }
        public string Cualidades { get; set; }
        public string RutaFoto { get; set; }
        
        public int AplicacionId { get; set; }
        public Aplicacion Aplicacion { get; set; }

        public ICollection<Chat> ChatsUsuarioOrigen { get; set; } //lo que mando
        public ICollection<Chat> ChatsUsuarioDestino { get; set; } //lo que recibo
        public ICollection<Publicacion> Publicaciones { get; set; }
        public ICollection<PublicacionGustada> PublicacionesGustadas { get; set; }
        public ICollection<UsuarioGustado> UsuariosSeguidores { get; set; } //los me siguen
        public ICollection<UsuarioGustado> UsuariosSeguidos { get; set; } //los que sigo
    }
}
