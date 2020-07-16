using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reserva.Models;

namespace Reserva.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TorneoEquipoController : ControllerBase
    {
        private readonly DBContext _context;
        public TorneoEquipoController(DBContext context)
        {
            _context = context;

        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<IEnumerable<TorneoEquipo>>> getTorneoEquipo()
        {
            return await _context.TorneoEquipo.ToArrayAsync();

            //return await _Db.Cancha.Include(x => x.complejo).ToArrayAsync();
        }

        [HttpGet("p")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<IEnumerable<TorneoEquipo>>> getTorneoEquipoxEquipo([FromQuery] int n1)
        {
            return await _context.TorneoEquipo.Where(x=>x.equipoId==n1).ToArrayAsync();

            //return await _Db.Cancha.Include(x => x.complejo).ToArrayAsync();
        }

        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<IEnumerable<TorneoEquipo>>> getTorneoEquipoId(int id)
        {
            return await _context.TorneoEquipo.Include(x => x.equipo).Where(i => i.torneoId == id).ToArrayAsync();
        }

        [HttpPost]
        public async Task<ActionResult<TorneoEquipo>> postTorneoEquipo(TorneoEquipo torneoEquipo)
        {
            var cat = await _context.Torneo.FindAsync(torneoEquipo.torneoId);
            var c = await _context.TorneoEquipo.Where(x => x.torneoId == torneoEquipo.torneoId).ToArrayAsync();
            var w = await _context.TorneoEquipo.FindAsync(torneoEquipo.torneoId, torneoEquipo.equipoId);
            var v = c.Length;

            //var m = await _context.TorneoEquipo.FindAsync(torneoEquipo.torneoId, torneoEquipo.equipoId);

            //if (torneoEquipo == m)
            //{
            //    return BadRequest("Este equipo ya esta registrado.");
            //}

            if (w != null)
            {
                return BadRequest("El equipo ya esta participando.");
            } else if (v < cat.cantEquipos)
            {
                _context.TorneoEquipo.Add(torneoEquipo);
                await _context.SaveChangesAsync();
                return Ok("Exito");
            }
            else
            {
                return BadRequest("Torneo ya esta lleno.");
            }



        }

        [HttpDelete("{idT}/{idE}")]
        public async Task<ActionResult> deleteTorneoEquipo(int idT, int idE)
        {
            var torneoEquipo = await _context.TorneoEquipo.FindAsync(idT, idE);
            if (torneoEquipo == null)
            {
                return NotFound();
            }
            _context.TorneoEquipo.Remove(torneoEquipo);
            await _context.SaveChangesAsync();
            return Ok("Exito");
        }
    }
}