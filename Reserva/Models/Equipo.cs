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
        public int idUsuario { get; set; }
        public Usuario usuario { get; set; }

        public class Map
        {
            public Map(EntityTypeBuilder<Equipo> _equipo)
            {
                _equipo.HasKey(x => x.idEquipo);
                _equipo.Property(x => x.nombre).HasColumnName("Nombre").HasMaxLength(20);
                _equipo.Property(x => x.idUsuario).HasColumnName("IdUsuario").HasColumnType("int");
                _equipo.HasOne(x => x.usuario);
            }
        }
    }
}
