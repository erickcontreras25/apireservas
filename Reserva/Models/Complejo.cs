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
        public string numero { get; set; }
        public string foto { get; set; }
        public bool estado { get; set; }
        public decimal? longitud { get; set; }
        public decimal? latitud { get; set; }
        public DateTime horaInicio { get; set; }
        public DateTime horaCierre { get; set; }
        public bool parqueo { get; set; }
        public bool seguridad { get; set; }
        public string userId { get; set; }
        public ApplicationUser user { get; set; }

        public class Map
        {
            public Map(EntityTypeBuilder<Complejo> _complejo)
            {
                _complejo.HasKey(x => x.idComplejo);
                _complejo.Property(x => x.nombre).HasColumnName("Nombre").HasMaxLength(20);
                _complejo.Property(x => x.localidad).HasColumnName("Localidad").HasMaxLength(20);
                _complejo.Property(x => x.numero).HasColumnName("Numero").HasMaxLength(20);
                _complejo.Property(x => x.foto).HasColumnName("Imagen").HasColumnType("Image");
                _complejo.Property(x => x.estado).HasColumnName("Estado").HasColumnType("bit");
                _complejo.Property(x => x.longitud).HasColumnName("Longitud").HasColumnType("real");
                _complejo.Property(x => x.latitud).HasColumnName("Latitud").HasColumnType("real");
                _complejo.Property(x => x.horaInicio).HasColumnName("HoraInicio").HasColumnType("Datetime");
                _complejo.Property(x => x.horaCierre).HasColumnName("HoraCierre").HasColumnType("Datetime");
                _complejo.Property(x => x.parqueo).HasColumnName("Parqueo").HasColumnType("bit");
                _complejo.Property(x => x.seguridad).HasColumnName("Seguridad").HasColumnType("bit");
                _complejo.Property(x => x.userId).HasColumnName("userId").HasMaxLength(450);
                _complejo.HasOne(x => x.user);
            }
        }
    }
}
