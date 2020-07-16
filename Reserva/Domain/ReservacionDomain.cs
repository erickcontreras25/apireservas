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
            var idCan = reservacion.idCancha;
            var hora = reservacion.idCancha;
            var idUs = reservacion.userId == string.Empty;
            var res = reservacion.horaFinal - reservacion.horaInicial;
            var r = res.TotalHours;
            //var result = DateTime.Compare(reservacion.horaFinal, reservacion.horaInicial);

            if (malaFecha)
            {
                return "La hora final no puede ser mayor que la inicial.";
            }
            if (malaFecha2)
            {
                return "La hora final no puede ser igual que la inicial.";
            }
            if (idCan == 0)
            {
                return "La cancha no puede ser nulo.";
            }
            if (idUs)
            {
                return "El usuario no puede ser nulo.";
            }
            if (r >= 4)
            {
                return "No puede reservar por mas de 4 horas.";
            }


            return null;
        }
    }
}
