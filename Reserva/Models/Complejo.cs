using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Reserva.Models
{
    public class Complejo
    {
        [Key]
        public int idComplejo { get; set; }
        public string nombre { get; set; }
        public string localidad { get; set; }
        public int cantCanchas { get; set; }
        public int adminId { get; set; }
        public Admin admin { get; set; }

        public class Map
        {
            public Map(EntityTypeBuilder<Complejo> _complejo)
            {
                _complejo.HasKey(x => x.idComplejo);
                _complejo.Property(x => x.nombre).HasColumnName("Nombre").HasMaxLength(20);
                _complejo.Property(x => x.localidad).HasColumnName("Localidad").HasMaxLength(20);
                _complejo.Property(x => x.cantCanchas).HasColumnName("CantidadDeCanchas").HasColumnType("int");
                _complejo.Property(x => x.adminId).HasColumnName("AdminId").HasColumnType("int");
                _complejo.HasOne(x => x.admin);
            }
        }
    }
}
