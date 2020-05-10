using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reserva.Models
{
    public class TorneoEquipo
    {
        public int torneoId { get; set; }
        public Torneo torneo { get; set; }
        public int equipoId { get; set; }
        public Equipo equipo { get; set; }
    }
}
