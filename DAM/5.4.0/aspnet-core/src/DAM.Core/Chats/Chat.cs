using Abp.Domain.Entities.Auditing;
using DAM.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAM.Chats
{
	public class Chat : FullAuditedEntity
	{
        [Required]
        public string Texto { get; set; }
        public DateTime? FechaHora { get; set; }
        public bool? IsEnviado { get; set; }
        public bool? IsRecibido { get; set; }
        
        [ForeignKey("UsuarioOrigenId")]
        public int UsuarioOrigenId { get; set; }
        public Usuario UsuarioOrigen { get; set; }
        [ForeignKey("UsuarioDestinoId")]
        public int UsuarioDestinoId { get; set; }        
        public Usuario UsuarioDestino { get; set; }
    }
}
