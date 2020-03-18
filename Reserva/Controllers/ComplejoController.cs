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
    public class ComplejoController : ControllerBase
    {
        private readonly DBContext _Db;
        private readonly ComplejoAppService _complejoAppServices;
        public ComplejoController(DBContext _DBcontext, ComplejoAppService complejoAppServices)
        {
            _Db = _DBcontext;
            _complejoAppServices = complejoAppServices;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Complejo>>> getComplejo()
        {
            return await _Db.Complejo.ToArrayAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Complejo>> getComplejoId(int id)
        {
            return await _Db.Complejo.FirstOrDefaultAsync(i => i.idComplejo == id);
        }

        [HttpPost]
        public async Task<ActionResult<Complejo>> postComplejo(Complejo complejo)
        {
            var respuesta = await _complejoAppServices.AgregarComplejo(complejo);
            if (respuesta == null)
            {
                return Ok("Exito");
            }
            else
            {
                return BadRequest(respuesta);
            }
        }

        [HttpPut("{idComplejo}")]

        public async Task<ActionResult> putComplejo(int idComplejo, Complejo complejo)
        {

            if (idComplejo == complejo.idComplejo)
            {
                _Db.Entry(complejo).State = EntityState.Modified;
                await _Db.SaveChangesAsync();
                return Ok();
            }

            return BadRequest();

        }

        [HttpDelete("{idComplejo}")]
        public async Task<ActionResult> deleteComplejo(int idComplejo)
        {
            var complejo = await _Db.Complejo.FindAsync(idComplejo);
            if (complejo == null)
            {
                return NotFound();
            }
            _Db.Complejo.Remove(complejo);
            await _Db.SaveChangesAsync();
            return Ok();
        }
    }
}