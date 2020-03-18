using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Reserva.Models
{
    public class Admin
    {
        [Key]
        public int idAdmin { get; set; }
        public string nombre { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public bool rol { get; set; }
        

        public class Map
        {
            public Map(EntityTypeBuilder<Admin> _admin)
            {
                _admin.HasKey(x => x.idAdmin);
                _admin.Property(x => x.nombre).HasColumnName("Nombre").HasMaxLength(20);
                _admin.Property(x => x.email).HasColumnName("Email").HasMaxLength(20);
                _admin.Property(x => x.password).HasColumnName("Password").HasMaxLength(20);
                _admin.Property(x => x.rol).HasColumnName("Rol").HasColumnType("bit");

            }
        }

    }
}
