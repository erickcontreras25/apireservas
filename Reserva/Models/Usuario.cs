using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Reserva.Models
{
    public class Usuario
    {
        [Key]
        public int idUsuario { get; set; }
        public string nombre { get; set; }
        public string nombreUsuario { get; set; }
        public int edad { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public bool rol { get; set; }

        public class Map
        {
            public Map(EntityTypeBuilder<Usuario> _usuario)
            {
                _usuario.HasKey(x => x.idUsuario);
                _usuario.Property(x => x.nombre).HasColumnName("Nombre").HasMaxLength(20);
                _usuario.Property(x => x.nombreUsuario).HasColumnName("NombreUsuario").HasMaxLength(20);
                _usuario.Property(x => x.edad).HasColumnName("Edad").HasColumnType("decimal");
                _usuario.Property(x => x.email).HasColumnName("Email").HasMaxLength(20);
                _usuario.Property(x => x.password).HasColumnName("Password").HasMaxLength(20);
                _usuario.Property(x => x.rol).HasColumnName("Rol").HasColumnType("bit");
                
            }
        }


    }
}
