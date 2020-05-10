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
    public class EquipoController : ControllerBase
    {
        private readonly DBContext _db;
        private readonly EquipoAppService _equipoAppService;

        public EquipoController(DBContext dbContext, EquipoAppService equipoAppService)
        {
            _db = dbContext;
            _equipoAppService = equipoAppService;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Equipo>>> getEquipo()
        {
            return await _db.Equipo.OrderBy(x=>x.nombre).ToArrayAsync();
        }

        [HttpGet("p")]
        public async Task<ActionResult<IEnumerable<Equipo>>> getEquipoxUser([FromQuery] string n1)
        {
            return await _db.Equipo.Where(x=>x.userId == n1).ToArrayAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Equipo>> getEquipoId(int id)
        {
            return await _db.Equipo.Include(x=>x.user).FirstOrDefaultAsync(i => i.idEquipo == id);
        }

        [HttpPost]
        public async Task<ActionResult<Complejo>> postEquipo(Equipo equipo)
        {
            var respuesta = await _equipoAppService.AgregarEquipo(equipo);
            if (respuesta == null)
            {
                return Ok("Exito");
            }
            else
            {
                return BadRequest(respuesta);
            }
        }

        [HttpPut("{idEquipo}")]

        public async Task<ActionResult> putEquipo(int idEquipo, Equipo equipo)
        {
            var cat = await _db.Torneo.FindAsync(idEquipo);
            var c = await _db.EquipoUser.Where(x => x.equipoId == idEquipo).ToArrayAsync();
            var v = c.Length;

            if(equipo.cantJugadores >= v)
            {
                if (idEquipo == equipo.idEquipo)
                {
                    _db.Entry(equipo).State = EntityState.Modified;
                    await _db.SaveChangesAsync();
                    return Ok("Exito");
                } else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest("La cantidad de jugadores no puede ser menor que los inscritos.");
            }
            

            

        }

        [HttpDelete("{idEquipo}")]
        public async Task<ActionResult> deleteEquipo(int idEquipo)
        {
            var equipo = await _db.Equipo.FindAsync(idEquipo);
            if (equipo == null)
            {
                return NotFound();
            }
            _db.Equipo.Remove(equipo);
            await _db.SaveChangesAsync();
            return Ok();
        }
    }
}