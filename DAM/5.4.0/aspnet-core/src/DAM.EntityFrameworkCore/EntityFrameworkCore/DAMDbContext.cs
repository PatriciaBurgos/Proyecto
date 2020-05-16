using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using DAM.Authorization.Roles;
using DAM.Authorization.Users;
using DAM.MultiTenancy;
using DAM.Publicaciones;
using DAM.Anuncios;
using DAM.Peticiones;
using DAM.UsuariosGustados;
using DAM.Chats;
using DAM.PublicacionesGustadas;

namespace DAM.EntityFrameworkCore
{
    public class DAMDbContext : AbpZeroDbContext<Tenant, Role, User, DAMDbContext>
    {
        /* Define a DbSet for each entity of the application */

        public DAMDbContext(DbContextOptions<DAMDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<Publicacion> Publicacion { get; set; }
        public DbSet<Anuncio> Anuncio { get; set; }
        public DbSet<Peticion> Peticion { get; set; }
        public DbSet<UsuarioGustado> UsuarioGustado { get; set; }
        public DbSet<Chat> Chat { get; set; }
        public DbSet<PublicacionGustada> PublicacionGustada { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Publicacion>()
            .HasOne<User>(publ => publ.Usuario)
            .WithMany(usu => usu.Publicaciones);

            modelBuilder.Entity<PublicacionGustada>()
            .HasOne<Publicacion>(publGus => publGus.Publicacion)
            .WithMany(pub => pub.PublicacionesGustadas);

            modelBuilder.Entity<Publicacion>()
            .HasOne<Anuncio>()
            .WithOne(anun => anun.Publicacion);

            modelBuilder.Entity<Publicacion>()
            .HasOne<Peticion>()
            .WithOne(pet => pet.Publicacion);
        
            modelBuilder.Entity<Chat>()
            .HasOne<User>(chat => chat.UsuarioOrigen)
            .WithMany(usu => usu.ChatsUsuarioOrigen);

            modelBuilder.Entity<Chat>()
            .HasOne<User>(chat => chat.UsuarioDestino)
            .WithMany(usu => usu.ChatsUsuarioDestino);

            modelBuilder.Entity<UsuarioGustado>()
            .HasOne<User>(usuGust => usuGust.UsuarioSeguidor)
            .WithMany(usu => usu.UsuariosSeguidores);

            modelBuilder.Entity<UsuarioGustado>()
            .HasOne<User>(usuGust => usuGust.UsuarioSeguido)
            .WithMany(usu => usu.UsuariosSeguidos);

            modelBuilder.Entity<PublicacionGustada>()
            .HasOne<User>(publGus => publGus.Usuario)
            .WithMany(usu => usu.PublicacionesGustadas);
        }
    }
}
