using Reserva.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reserva.Domain
{
    public class ComplejoDomain
    {
        public string AgregarComplejo(Complejo complejo)
        {
            if (complejo == null)
            {
                return "Por favor ingrese datos para el complejo";
            }


            int maximoCarcteresParaNombre = 20;
            int cantidadDeCanchas;
            var nombreEsDemasiadoLargo = complejo.nombre.Count() > maximoCarcteresParaNombre;
            var nombreEstaEnBlanco = complejo.nombre == string.Empty;


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
