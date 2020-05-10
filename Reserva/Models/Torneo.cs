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
        public string nombre { get; set; }
        public int cantEquipos { get; set; }
        public string descripcion { get; set; }
        public string premioFoto { get; set; }
        public DateTime diaTorneo { get; set; }
        public string usuarioId { get; set; }        
        public int idComplejo { get; set; }
        public Complejo complejo { get; set; }
        public List<TorneoEquipo> torneoEquipo { get; set; }

        public class Map
        {
            public Map(EntityTypeBuilder<Torneo> _torneo)
            {
                _torneo.HasKey(x => x.idTorneo);
                _torneo.Property(x => x.nombre).HasColumnName("Nombre").HasMaxLength(20);
                _torneo.Property(x => x.cantEquipos).HasColumnName("CantidadEquipos").HasColumnType("decimal");
                _torneo.Property(x => x.descripcion).HasColumnName("Descripcion").HasMaxLength(20);
                _torneo.Property(x => x.premioFoto).HasColumnName("PremioFoto").HasColumnType("Image");
                _torneo.Property(x => x.diaTorneo).HasColumnName("DiaTorneo").HasColumnType("Datetime");
                _torneo.Property(x => x.usuarioId).HasColumnName("UsuarioId").HasMaxLength(450);
                _torneo.Property(x => x.idComplejo).HasColumnName("idComplejo").HasColumnType("int");
                _torneo.HasOne(x => x.complejo);

            }
        }

    }
}
