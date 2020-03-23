using Reserva.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reserva.Domain
{
    public class AdminDomain
    {
        public string AgregarAdmin(Admin admin)
        {
            if (admin == null)
            {
                return "Por favor ingrese datos para el usuario";
            }


            int maximoCarcteresParaNombre = 20;
            var nombreEsDemasiadoLargo = admin.nombre.Count() > maximoCarcteresParaNombre;
            var nombreEstaEnBlanco = admin.nombre == string.Empty;
            var email = admin.email == string.Empty;
            var pass = admin.password == string.Empty;


            if (nombreEstaEnBlanco)
            {
                return "El nombre no puede ser nulo.";
            }
            if (email)
            {
                return "El email no puede ser nulo.";
            }
            if (pass)
            {
                return "La contrasenia no puede ser nula.";
            }

            if (nombreEsDemasiadoLargo)
            {
                return "El nombre contiene mas caracteres de lo permitido.";

            }

            return null;
        }

    }
}
