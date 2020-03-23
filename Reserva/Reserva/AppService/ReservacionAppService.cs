using Reserva.Domain;
using Reserva.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reserva.AppService
{
    public class ReservacionAppService
    {
        private readonly DBContext _dB;
        private readonly ReservacionDomain _reservacionDomain;

        public ReservacionAppService(DBContext db, ReservacionDomain reservacionDomain)
        {
            _dB = db;
            _reservacionDomain = reservacionDomain;
        }

        public async Task<string> AgregarCancha(Reservaciones reservacion)
        {

            var respuesta = _reservacionDomain.AgregarReservacion(reservacion);

            bool hayError = respuesta != null;

            if (hayError)
            {
                return respuesta;
            }

            try
            {
                _dB.Reservacion.Add(reservacion);
                await _dB.SaveChangesAsync();

                return null;
            }
            catch (Exception e)
            {
                return e.Message;
            }


        }
    }
}
