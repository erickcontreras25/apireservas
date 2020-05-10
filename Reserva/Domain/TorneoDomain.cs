using Reserva.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reserva.Domain
{
    public class TorneoDomain
    {
        public string AgregarTorneo(Torneo torneo)
        {
            if (torneo == null)
            {
                return "Por favor ingrese datos para el complejo";
            }


            int maximoCarcteresParaNombre = 20;
            var nombreEsDemasiadoLargo = torneo.nombre.Count() > maximoCarcteresParaNombre;
            var nombreEstaEnBlanco = torneo.nombre == string.Empty;
            var cantidadEquipos = torneo.cantEquipos;
            var hoy = DateTime.Now.ToLocalTime();
            var fechaTorneo = torneo.diaTorneo.ToLocalTime();
            int result = DateTime.Compare(fechaTorneo, hoy);


            if (nombreEstaEnBlanco)
            {
                return "El nombre no puede ser nulo.";
            }

            if (nombreEsDemasiadoLargo)
            {
                return "El nombre contiene mas caracteres de lo permitido.";

            }

            if (cantidadEquipos == 0)
            {
                return "La cantidad de equipos no puede ser cero";
            }

            if (result < 0)
            {
                return "El dia del torneo no puede ser anterior al dia de hoy";
            }

            if (result == 0)
            {
                return "El dia del torneo no puede ser el mismo dia de hoy";
            }

            return null;
        }
    }
}
