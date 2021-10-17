using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace postgres.Data
{
    public class ApplicationDbContext : IdentityDbContext<Usuario>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);//se invoca el metodo origina y luego el nuestro

            builder.Entity<Usuario>(entityTypeBuilder =>//espesificamos que entidad vamos a modificar
            {
                entityTypeBuilder.ToTable("Usuarios");//de esta manera renombramos la tabla al nombre que indicamos aqui

                entityTypeBuilder.Property(u => u.UserName)
                    .HasMaxLength(100)
                    .HasDefaultValue(0);
                entityTypeBuilder.Property(u => u.Nombre)
                    .HasMaxLength(60);
                entityTypeBuilder.Property(u => u.Nombre)
                    .HasMaxLength(60);
                entityTypeBuilder.Property(u => u.Apellido)
                    .HasMaxLength(60);
                entityTypeBuilder.Property(u => u.Depto)
                    .HasMaxLength(25);
                entityTypeBuilder.Property(u => u.DPI)
                    .HasMaxLength(20);
                entityTypeBuilder.Property(u => u.NIT)
                    .HasMaxLength(20);                
            });
        }
    }

    public class Usuario : IdentityUser
    {
        public string Nombre {get;set;}
        public string Apellido { get; set; }
        public string Sexo { get; set; }
        public DateTime Fecha_nacimiento { get; set; }
        public string Depto { get; set; }
        public string NIT { get; set; }
        public string DPI { get; set; }

    }
}
