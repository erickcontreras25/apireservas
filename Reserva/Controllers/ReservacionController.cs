﻿using System;
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
    public class ReservacionController : ControllerBase
    {
        private readonly DBContext _db;
        private readonly ReservacionAppService _reservacionAppService;

        public ReservacionController(DBContext db, ReservacionAppService reservacionAppService)
        {
            _db = db;
            _reservacionAppService = reservacionAppService;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservaciones>>> getReservacion()
        {
            return await _db.Reservacion.ToArrayAsync();
            //return await _Db.Cancha.Include(x => x.complejo).ToArrayAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Reservaciones>> getReservacionId(int id)
        {
            return await _db.Reservacion.Include(x => x.usuario).Include(y => y.cancha).FirstOrDefaultAsync(i => i.idReservacion == id);
        }

        [HttpPost]
        public async Task<ActionResult<Reservaciones>> postReservacion(Reservaciones reservacion)
        {
            var respuesta = await _reservacionAppService.AgregarCancha(reservacion);
            if (respuesta == null)
            {
                return Ok("Exito");
            }
            else
            {
                return BadRequest(respuesta);
            }
        }

        [HttpPut("{idReservacion}")]

        public async Task<ActionResult> putReservacion(int idReservacion, Reservaciones reservacion)
        {

            if (idReservacion == reservacion.idReservacion)
            {
                _db.Entry(reservacion).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return Ok();
            }

            return BadRequest();

        }

        [HttpDelete("{idReservacion}")]
        public async Task<ActionResult> deleteReservacion(int idReservacion)
        {
            var reservacion = await _db.Reservacion.FindAsync(idReservacion);
            if (reservacion == null)
            {
                return NotFound();
            }
            _db.Reservacion.Remove(reservacion);
            await _db.SaveChangesAsync();
            return Ok();
        }
    }
}