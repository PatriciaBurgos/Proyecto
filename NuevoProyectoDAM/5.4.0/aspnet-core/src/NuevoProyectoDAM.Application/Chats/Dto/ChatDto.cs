using Abp.Application.Services.Dto;
using NuevoProyectoDAM.Users.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace NuevoProyectoDAM.Chats.Dto
{
	public class ChatDto : EntityDto
	{
        public string Texto { get; set; }
        public DateTime? FechaHora { get; set; }
        public bool? IsEnviado { get; set; }
        public bool? IsRecibido { get; set; }

        public long UsuarioOrigenId { get; set; }
        public string UsuarioOrigen { get; set; }

        public long UsuarioDestinoId { get; set; }
        public string UsuarioDestino { get; set; }
    }
}
