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
            return await _db.Equipo.Include(x => x.usuario).ToArrayAsync();
        }

        [HttpGet("p")]
        [Route("api/equipoUsuario")]
        public async Task<ActionResult<IEnumerable<Equipo>>> getEquipoFiltrado([FromQuery] decimal n1)
        {
            return await _db.Equipo.Include(x => x.usuario).Where(y=>y.idUsuario==n1).ToArrayAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Equipo>> getEquipoId(int id)
        {
            return await _db.Equipo.Include(x => x.usuario).FirstOrDefaultAsync(i => i.idEquipo == id);
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

        [HttpPut("{idComplejo}")]

        public async Task<ActionResult> putEquipo(int idEquipo, Equipo equipo)
        {

            if (idEquipo == equipo.idEquipo)
            {
                _db.Entry(equipo).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return Ok();
            }

            return BadRequest();

        }

        [HttpDelete("{idComplejo}")]
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