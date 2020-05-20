using System;
using System.Collections.Generic;
using System.Text;

namespace NuevoProyectoDAM.Chats.Dto
{
	public class MostrarChatReducidoDto
	{
        public string Texto { get; set; }
        public DateTime? FechaHora { get; set; }

        public string UsuarioOrigen { get; set; }
        public string UsuarioDestino { get; set; }

    }
}
