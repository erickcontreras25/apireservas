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
        public int idCancha { get; set; }
        public Cancha cancha { get; set; }
        public int idUsuario { get; set; }
        public Usuario usuario { get; set; }


        public class Map
        {
            public Map(EntityTypeBuilder<Reservaciones> _reservacion)
            {
                _reservacion.HasKey(x => x.idReservacion);
                _reservacion.Property(x => x.horaInicial).HasColumnName("HoraInicial").HasColumnType("Datetime");
                _reservacion.Property(x => x.horaFinal).HasColumnName("HoraFinal").HasColumnType("Datetime");
                _reservacion.Property(x => x.idCancha).HasColumnName("idCancha").HasColumnType("int");
                _reservacion.HasOne(x => x.cancha);
                _reservacion.Property(x => x.idUsuario).HasColumnName("IdUsuario").HasColumnType("int");
                _reservacion.HasOne(x => x.usuario);
            }
        }
    }
}
