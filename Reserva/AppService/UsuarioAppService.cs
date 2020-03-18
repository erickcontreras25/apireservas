using Reserva.Domain;
using Reserva.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reserva.AppService
{
    public class UsuarioAppService
    {
        private readonly DBContext _dB;
        private readonly UsuarioDomain _usuarioDomain;

        public UsuarioAppService(DBContext db, UsuarioDomain usuarioDomain)
        {
            _dB = db;
            _usuarioDomain = usuarioDomain;
        }

        public async Task<string> AgregarUsuario(Usuario usuario)
        {

            var respuesta = _usuarioDomain.AgregarUsuario(usuario);

            bool hayError = respuesta != null;

            if (hayError)
            {
                return respuesta;
            }

            try
            {
                _dB.Usuario.Add(usuario);
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
