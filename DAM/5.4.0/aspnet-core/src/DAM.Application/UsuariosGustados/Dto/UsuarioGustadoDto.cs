﻿using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAM.UsuarioGustado.Dto
{
	public class UsuarioGustadoDto : EntityDto
	{
		public int IdUsuario { get; set; }
		public int IdSeguidor { get; set; }
	}
}
