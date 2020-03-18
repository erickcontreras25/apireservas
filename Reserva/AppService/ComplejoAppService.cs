using Reserva.Domain;
using Reserva.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reserva.AppService
{
    public class ComplejoAppService
    {
        private readonly DBContext _dB;
        private readonly ComplejoDomain _complejoDomain;
        public ComplejoAppService(DBContext db, ComplejoDomain complejoDomain)
        {
            _dB = db;
            _complejoDomain = complejoDomain;
        }

        public async Task<string> AgregarComplejo(Complejo complejo)
        {

            var respuesta = _complejoDomain.AgregarComplejo(complejo);

            bool hayError = respuesta != null;

            if (hayError)
            {
                return respuesta;
            }

            try
            {
                _dB.Complejo.Add(complejo);
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
