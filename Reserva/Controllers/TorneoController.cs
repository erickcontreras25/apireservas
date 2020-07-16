using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reserva.AppService;
using Reserva.Models;

namespace Reserva.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TorneoController : ControllerBase
    {
        private readonly DBContext _db;
        private readonly TorneoAppService _torneoAppService;

        public TorneoController(DBContext dbContext, TorneoAppService torneoAppService)
        {
            _db = dbContext;
            _torneoAppService = torneoAppService;

        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<IEnumerable<Torneo>>> getTorneo()
        {
            return await _db.Torneo.Include(x=>x.complejo).OrderBy(x=>x.diaTorneo).ToArrayAsync();
        }

        [HttpGet("p")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<IEnumerable<Torneo>>> getTorneoxUser([FromQuery] string n1)
        {
            return await _db.Torneo.Where(x=>x.usuarioId == n1).OrderByDescending(y=>y.diaTorneo).ToArrayAsync();
        }

        [HttpGet("q")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<IEnumerable<Torneo>>> getTorneoxComplejo([FromQuery] decimal id)
        {
            return await _db.Torneo.Where(x => x.idComplejo == id).ToArrayAsync();
        }


        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Torneo>> getTorneoId(int id)
        {
            return await _db.Torneo.Include(x=>x.complejo).FirstOrDefaultAsync(i => i.idTorneo == id);
        }

        [HttpPost]
        public async Task<ActionResult<Torneo>> postTorneo(Torneo torneo)
        {
            var respuesta = await _torneoAppService.AgregarTorneo(torneo);
            if (respuesta == null)
            {
                return Ok("Exito");
            }
            else
            {
                return BadRequest(respuesta);
            }
        }

        [HttpPut("{idTorneo}")]

        public async Task<ActionResult> putTorneo(int idTorneo, Torneo torneo)
        {

            if (idTorneo == torneo.idTorneo)
            {
                _db.Entry(torneo).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return Ok();
            }

            return BadRequest();

        }

        [HttpDelete("{idTorneo}")]
        public async Task<ActionResult> deleteTorneo(int idTorneo)
        {
            var torneo = await _db.Torneo.FindAsync(idTorneo);
            if (torneo == null)
            {
                return NotFound();
            }
            _db.Torneo.Remove(torneo);
            await _db.SaveChangesAsync();
            return Ok();
        }
    }
}