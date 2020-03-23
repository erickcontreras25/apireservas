using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Reserva.Models
{
    public class Cancha
    {
        [Key]
        public int idCancha { get; set; }
        public int precio { get; set; }
        public string estado { get; set; }
        public int idComplejo { get; set; }
        public Complejo complejo { get; set; }


        public class Map
        {
            public Map(EntityTypeBuilder<Cancha> _cancha)
            {
                _cancha.HasKey(x => x.idCancha);
                _cancha.Property(x => x.precio).HasColumnName("Precio").HasColumnType("int");
                _cancha.Property(x => x.estado).HasColumnName("Estado").HasMaxLength(20);
                _cancha.Property(x => x.idComplejo).HasColumnName("idComplejo").HasColumnType("int");
                _cancha.HasOne(x => x.complejo);
            }
        }
    }
}
