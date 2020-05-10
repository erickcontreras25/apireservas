using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Reserva.Models
{
    public class Reservaciones
    {
        [Key]
        public int idReservacion { get; set; }
        public DateTime horaInicial { get; set; }
        public DateTime horaFinal { get; set; }
        public bool pago { get; set; }
        public bool pagoParcial { get; set; }
        public int idCancha { get; set; }
        public Cancha cancha { get; set; }
        public string userId { get; set; }
        public ApplicationUser user { get; set; }


        public class Map
        {
            public Map(EntityTypeBuilder<Reservaciones> _reservacion)
            {
                _reservacion.HasKey(x => x.idReservacion);
                _reservacion.Property(x => x.horaInicial).HasColumnName("HoraInicial").HasColumnType("Datetime");
                _reservacion.Property(x => x.horaFinal).HasColumnName("HoraFinal").HasColumnType("Datetime");
                _reservacion.Property(x=>x.pago).HasColumnName("Pago").HasColumnType("bit");
                _reservacion.Property(x => x.idCancha).HasColumnName("idCancha").HasColumnType("int");
                _reservacion.HasOne(x => x.cancha);
                _reservacion.Property(x => x.userId).HasColumnName("userId").HasMaxLength(450);
                _reservacion.HasOne(x => x.user);
            }
        }
    }
}
