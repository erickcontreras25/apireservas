using Reserva.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reserva.Domain
{
    public class CanchaDomain
    {
        public string AgregarCancha(Cancha cancha)
        {
            if (cancha == null)
            {
                return "Por favor ingrese datos para la cancha";
            }


            int precio = cancha.precio;
            int idRelacion = cancha.idComplejo;


            if (precio == 0)
            {
                return "El precio no puede ser nulo.";
            }
            if (idRelacion == 0)
            {
                return "Necesita el id del Complejo";
            }

            return null;
        }
    }
}
