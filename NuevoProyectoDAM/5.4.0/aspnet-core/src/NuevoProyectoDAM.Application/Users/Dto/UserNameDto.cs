using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using NuevoProyectoDAM.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace NuevoProyectoDAM.Users.Dto
{
	[AutoMapFrom(typeof(User))]
	public class UserNameDto : EntityDto<long>
	{
		public String UserName { get; set; }
	}
}
