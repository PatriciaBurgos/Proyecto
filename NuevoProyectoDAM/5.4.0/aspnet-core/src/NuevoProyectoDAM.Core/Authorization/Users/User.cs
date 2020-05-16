using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Authorization.Users;
using Abp.Extensions;
using DAM.Chats;
using DAM.Publicaciones;
using DAM.PublicacionesGustadas;
using DAM.UsuariosGustados;

namespace NuevoProyectoDAM.Authorization.Users
{
    public class User : AbpUser<User>
    {
        public const string DefaultPassword = "123qwe";

        public static string CreateRandomPassword()
        {
            return Guid.NewGuid().ToString("N").Truncate(16);
        }

        public DateTime BirthDate { get; set; }
        [MaxLength(50)]
        public String? Town { get; set; }
        [MaxLength(50)]
        public String City { get; set; }
        [MaxLength(256)]
        public String? Qualities { get; set; }
        public String Photo { get; set; }

        public ICollection<Chat> ChatsUsuarioOrigen { get; set; } //lo que mando
        public ICollection<Chat> ChatsUsuarioDestino { get; set; } //lo que recibo
        public ICollection<Publicacion> Publicaciones { get; set; }
        public ICollection<PublicacionGustada> PublicacionesGustadas { get; set; }
        public ICollection<UsuarioGustado> UsuariosSeguidores { get; set; } //los me siguen
        public ICollection<UsuarioGustado> UsuariosSeguidos { get; set; } //los que sigo

        public static User CreateTenantAdminUser(int tenantId, string emailAddress)
        {
            var user = new User
            {
                TenantId = tenantId,
                UserName = AdminUserName,
                Name = AdminUserName,
                Surname = AdminUserName,
                EmailAddress = emailAddress,
                Roles = new List<UserRole>()
            };

            user.SetNormalizedNames();

            return user;
        }
    }
}
