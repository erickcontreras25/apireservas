using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Reserva.Models
{
    public class Equipo
    {
        [Key]
        public int idEquipo { get; set; }
        public string nombre { get; set; }
        public int cantJugadores { get; set; }
        public string userId { get; set; }        
        public ApplicationUser user { get; set; }
        public List<EquipoUser> equipoUser { get; set; }
        public List<TorneoEquipo> torneoEquipo { get; set; }

        public class Map
        {
            public Map(EntityTypeBuilder<Equipo> _equipo)
            {
                _equipo.HasKey(x => x.idEquipo);
                _equipo.Property(x => x.nombre).HasColumnName("Nombre").HasMaxLength(20);
                _equipo.Property(x => x.cantJugadores).HasColumnName("CantidadJug").HasColumnType("int");
                _equipo.Property(x => x.userId).HasColumnName("userId").HasMaxLength(450);
                _equipo.HasOne(x => x.user);
            }
        }
    }
}
