using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using DAM.Authorization.Roles;
using DAM.Authorization.Users;
using DAM.MultiTenancy;
using DAM.Aplicaciones;
using DAM.Usuarios;
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
        public DbSet<Aplicacion>Aplicacion { get; set; }  
        public DbSet<Usuario> Usuario { get; set; }
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
            .HasOne<Aplicacion>(publ => publ.Aplicacion)
            .WithMany(apl => apl.Publicaciones);

            modelBuilder.Entity<Publicacion>()
            .HasOne<Usuario>(publ => publ.Usuario)
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

            modelBuilder.Entity<Usuario>()
            .HasOne<Aplicacion>(usu => usu.Aplicacion)
            .WithMany(apl => apl.Usuarios);

            modelBuilder.Entity<Chat>()
            .HasOne<Usuario>(chat => chat.UsuarioOrigen)
            .WithMany(usu => usu.ChatsUsuarioOrigen);

            modelBuilder.Entity<Chat>()
            .HasOne<Usuario>(chat => chat.UsuarioDestino)
            .WithMany(usu => usu.ChatsUsuarioDestino);

            modelBuilder.Entity<UsuarioGustado>()
            .HasOne<Usuario>(usuGust => usuGust.UsuarioSeguidor)
            .WithMany(usu => usu.UsuariosSeguidores);

            modelBuilder.Entity<UsuarioGustado>()
            .HasOne<Usuario>(usuGust => usuGust.UsuarioSeguido)
            .WithMany(usu => usu.UsuariosSeguidos);

            modelBuilder.Entity<PublicacionGustada>()
            .HasOne<Usuario>(publGus => publGus.Usuario)
            .WithMany(usu => usu.PublicacionesGustadas);
        }
    }
}
