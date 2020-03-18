using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reserva.AppService;
using Reserva.Models;

namespace Reserva.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly DBContext _db;
        private readonly AdminAppService _adminAppServices;

        public AdminController(DBContext db, AdminAppService adminAppServices)
        {
            _db = db;
            _adminAppServices = adminAppServices;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Admin>>> getAdmin()
        {
            return await _db.Admin.ToArrayAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Admin>> getAdminId(int id)
        {
            return await _db.Admin.FirstOrDefaultAsync(i => i.idAdmin == id);
        }

        [HttpPost]
        public async Task<ActionResult<Admin>> postAdmin(Admin admin)
        {
            var respuesta = await _adminAppServices.AgregarAdmin(admin);
            if (respuesta == null)
            {
                return Ok("Exito");
            }
            else
            {
                return BadRequest(respuesta);
            }
        }

        [HttpPut("{idAdmin}")]

        public async Task<ActionResult> putAdmin(int idAdmin, Admin admin)
        {

            if (idAdmin == admin.idAdmin)
            {
                _db.Entry(admin).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return Ok();
            }

            return BadRequest();

        }

        [HttpDelete("{idAdmin}")]
        public async Task<ActionResult> deleteAdmin(int idAdmin)
        {
            var admin = await _db.Admin.FindAsync(idAdmin);
            if (admin == null)
            {
                return NotFound();
            }
            _db.Admin.Remove(admin);
            await _db.SaveChangesAsync();
            return Ok();
        }


    }
}