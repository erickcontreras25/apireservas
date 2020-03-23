using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reserva.AppService;
using Reserva.Models;
using Reserva;

namespace Reserva.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CanchaController : ControllerBase
    {
        private readonly DBContext _Db;
        private readonly CanchaAppService _canchaAppService;
        public CanchaController(DBContext _DBcontext, CanchaAppService canchaAppService)
        {
            _Db = _DBcontext;
            _canchaAppService = canchaAppService;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cancha>>> getCancha([FromQuery] decimal n1)
        {
            //return await _Db.Cancha.ToArrayAsync();
            return await _Db.Cancha.Include(x => x.complejo).Where(y=>y.idComplejo==n1).ToArrayAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cancha>> getCanchaId(int id)
        {
            return await _Db.Cancha.Include(x => x.complejo).FirstOrDefaultAsync(i => i.idCancha == id);
        }

        [HttpPost]
        public async Task<ActionResult<Cancha>> postCanchas(Cancha cancha)
        {
            var respuesta = await _canchaAppService.AgregarCancha(cancha);
            if (respuesta == null)
            {
                return Ok("Exito");
            }
            else
            {
                return BadRequest(respuesta);
            }
        }

        [HttpPut("{idCancha}")]

        public async Task<ActionResult> putCanchas(int idCancha, Cancha cancha)
        {

            if (idCancha == cancha.idCancha)
            {
                _Db.Entry(cancha).State = EntityState.Modified;
                await _Db.SaveChangesAsync();
                return Ok();
            }

            return BadRequest();

        }

        [HttpDelete("{idCancha}")]
        public async Task<ActionResult> deleteCanchas(int idCancha)
        {
            var cancha = await _Db.Cancha.FindAsync(idCancha);
            if (cancha == null)
            {
                return NotFound();
            }
            _Db.Cancha.Remove(cancha);
            await _Db.SaveChangesAsync();
            return Ok();
        }
    }
}