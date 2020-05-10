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
            bool malaFecha2 = reservacion.horaInicial == reservacion.horaFinal;
            var idCan = reservacion.idCancha == 0;
            var hora = reservacion.idCancha;
            var idUs = reservacion.userId == "";
            var result = DateTime.Compare(reservacion.horaFinal, reservacion.horaInicial);

            if (malaFecha)
            {
                return "La hora final no puede ser mayor que la inicial.";
            }
            if (malaFecha2)
            {
                return "La hora final no puede ser igual que la inicial.";
            }
            if (idCan)
            {
                return "La cancha no puede ser nulo.";
            }
            if (idUs)
            {
                return "El usuario no puede ser nulo.";
            }
            if (result >= 4)
            {
                return "No puede reservar por mas de 4 horas.";
            }


            return null;
        }
    }
}
