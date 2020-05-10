using Reserva.Domain;
using Reserva.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reserva.AppService
{
    public class TorneoAppService
    {
        private readonly DBContext _db;
        private readonly TorneoDomain _torneoDomain;
        public TorneoAppService(DBContext db, TorneoDomain torneoDomain)
        {
            _db = db;
            _torneoDomain = torneoDomain;
        }

        public async Task<string> AgregarTorneo(Torneo torneo)
        {

            var respuesta = _torneoDomain.AgregarTorneo(torneo);

            bool hayError = respuesta != null;

            if (hayError)
            {
                return respuesta;
            }

            try
            {
                _db.Torneo.Add(torneo);
                await _db.SaveChangesAsync();

                return null;
            }
            catch (Exception e)
            {
                return e.Message;
            }


        }
    }
}
