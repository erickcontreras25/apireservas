using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Reserva.Models
{
    public class Torneo
    {
        [Key]
        public int idTorneo { get; set; }
        public string nombreTorneo { get; set; }
        public int cantEquipos { get; set; }
        public string premio { get; set; }

        public class Map
        {
            public Map(EntityTypeBuilder<Torneo> _torneo)
            {
                _torneo.HasKey(x => x.idTorneo);
                _torneo.Property(x => x.nombreTorneo).HasColumnName("NombreTorneo").HasMaxLength(20);
                _torneo.Property(x => x.cantEquipos).HasColumnName("CantidadEquipos").HasColumnType("decimal");
                _torneo.Property(x => x.premio).HasColumnName("Premio").HasMaxLength(20);

            }
        }

    }
}
