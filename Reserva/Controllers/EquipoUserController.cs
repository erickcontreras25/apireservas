using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reserva.Models;

namespace Reserva.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipoUserController : ControllerBase
    {
        private readonly DBContext _context;
        public EquipoUserController(DBContext context)
        {
            _context = context;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipoUser>>> getEquipoUser()
        {
            return await _context.EquipoUser.ToArrayAsync();
            //return await _Db.Cancha.Include(x => x.complejo).ToArrayAsync();
        }

        [HttpGet("p")]
        public async Task<ActionResult<IEnumerable<EquipoUser>>> getEquipoUserxUser([FromQuery] string n1)
        {
            return await _context.EquipoUser.Include(x => x.equipo).Where(x=>x.userId == n1).ToArrayAsync();
            //return await _Db.Cancha.Include(x => x.complejo).ToArrayAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<EquipoUser>>> getEquipoUserId(int id)
        {
            return await _context.EquipoUser.Include(x => x.user).Where(x => x.equipoId == id).ToArrayAsync();
        }

        [HttpPost]
        public async Task<ActionResult<EquipoUser>> postEquipoUser(EquipoUser equipoUser)
        {
            var cat = await _context.Equipo.FindAsync(equipoUser.equipoId);
            var c = await _context.EquipoUser.Where(x => x.equipoId == equipoUser.equipoId).ToArrayAsync();
            var w = await _context.EquipoUser.FindAsync(equipoUser.equipoId, equipoUser.userId);
            var v = c.Length;


            if (w != null)
            {
                return BadRequest("Ya esta unido a este equipo");
            }
            else if (v < cat.cantJugadores)
            {
                _context.EquipoUser.Add(equipoUser);
                await _context.SaveChangesAsync();
                return Ok("Exito");
            }
            else
            {
                return BadRequest("El equipo esta lleno.");
            }

            //if (v == cat.cantJugadores)
            //{
            //    return BadRequest("El equipo esta lleno.");
            //}
            //else
            //    {
            //    if (v < cat.cantJugadores)
            //    {
            //        try
            //        {
            //            _context.EquipoUser.Add(equipoUser);
            //            await _context.SaveChangesAsync();
            //            return Ok("Exito");
            //        }
            //        catch (Exception e)
            //        {

            //        }
                    
            //    }
            //}

            



        }

        [HttpDelete("{id}/{idu}")]
        public async Task<ActionResult> deleteEquipoUser(int id, string idu)
        {
            var equipoUser = await _context.EquipoUser.FindAsync(id, idu);
            if (equipoUser == null)
            {
                return NotFound();
            }
            _context.EquipoUser.Remove(equipoUser);
            await _context.SaveChangesAsync();
            return Ok("Exito");
        }
    }
}