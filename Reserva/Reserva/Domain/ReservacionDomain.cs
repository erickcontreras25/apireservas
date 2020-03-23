using Reserva.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reserva.Domain
{
    public class ReservacionDomain
    {
        public string AgregarReservacion(Reservaciones reservacion)
        {
            if (reservacion == null)
            {
                return "Por favor ingrese datos para la cancha";
            }

            bool malaFecha = reservacion.horaInicial > reservacion.horaFinal;
            var idCan = reservacion.idCancha == 0;
            //var idUsu = reservacion.idUsuario == 0;

            if (malaFecha)
            {
                return "La hora final no puede ser mayor que la inicial";
            }
            if (idCan)
            {
                return "La cancha no puede ser nulo";
            }
            //if (idUsu)
            //{
            //    return "El usuario no puede ser nulo";
            //}


            return null;
        }
    }
}
