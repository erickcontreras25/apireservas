using Reserva.Domain;
using Reserva.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reserva.AppService
{
    public class EquipoAppService
    {
        private readonly DBContext _dB;
        private readonly EquipoDomain _equipoDomain;
        public EquipoAppService(DBContext db, EquipoDomain equipoDomain)
        {
            _dB = db;
            _equipoDomain = equipoDomain;
        }

        public async Task<string> AgregarEquipo(Equipo equipo)
        {

            var respuesta = _equipoDomain.AgregarEquipo(equipo);

            bool hayError = respuesta != null;

            if (hayError)
            {
                return respuesta;
            }

            try
            {
                _dB.Equipo.Add(equipo);
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
