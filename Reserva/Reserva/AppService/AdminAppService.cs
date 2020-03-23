using Reserva.Domain;
using Reserva.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reserva.AppService
{
    public class AdminAppService
    {
        private readonly DBContext _db;
        private readonly AdminDomain _admiDomain;

        public AdminAppService(DBContext db, AdminDomain admiDomain)
        {
            _db = db;
            _admiDomain = admiDomain;
        }

        public async Task<string> AgregarAdmin(Admin admin)
        {

            var respuesta = _admiDomain.AgregarAdmin(admin);

            bool hayError = respuesta != null;

            if (hayError)
            {
                return respuesta;
            }

            try
            {
                _db.Admin.Add(admin);
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
