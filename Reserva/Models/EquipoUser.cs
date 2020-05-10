using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reserva.Models
{
    public class EquipoUser
    {
        public int equipoId { get; set; }
        public Equipo equipo { get; set; }
        public string userId { get; set; }
        public ApplicationUser user { get; set; }
    }
}
