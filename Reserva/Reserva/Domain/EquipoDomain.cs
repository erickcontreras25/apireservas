using Reserva.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reserva.Domain
{
    public class EquipoDomain
    {
        public string AgregarEquipo(Equipo equipo)
        {
            if (equipo == null)
            {
                return "Por favor ingrese datos para el complejo";
            }


            int maximoCarcteresParaNombre = 20;
            var nombreEsDemasiadoLargo = equipo.nombre.Count() > maximoCarcteresParaNombre;
            var nombreEstaEnBlanco = equipo.nombre == string.Empty;


            if (nombreEstaEnBlanco)
            {
                return "El nombre no puede ser nulo.";
            }

            if (nombreEsDemasiadoLargo)
            {
                return "El nombre contiene mas caracteres de lo permitido.";

            }

            return null;
        }
    }
}
