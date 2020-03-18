using Reserva.Domain;
using Reserva.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reserva.AppService
{
    public class CanchaAppService
    {
        private readonly DBContext _dB;
        private readonly CanchaDomain _canchaDomain;
        public CanchaAppService(DBContext db, CanchaDomain canchaDomain)
        {
            _dB = db;
            _canchaDomain = canchaDomain;
        }

        public async Task<string> AgregarCancha(Cancha cancha)
        {

            var respuesta = _canchaDomain.AgregarCancha(cancha);

            bool hayError = respuesta != null;

            if (hayError)
            {
                return respuesta;
            }

            try
            {
                _dB.Cancha.Add(cancha);
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
