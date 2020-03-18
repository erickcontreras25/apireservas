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
    public class UsuarioController : ControllerBase
    {
        private readonly DBContext _db;
        private readonly UsuarioAppService _usuarioAppServices;

        public UsuarioController(DBContext db, UsuarioAppService usuarioAppServices)
        {
            _db = db;
            _usuarioAppServices = usuarioAppServices;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> getUsuario()
        {
            return await _db.Usuario.ToArrayAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> getUsuarioId(int id)
        {
            return await _db.Usuario.FirstOrDefaultAsync(i => i.idUsuario == id);
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> postUsuario(Usuario usuario)
        {
            var respuesta = await _usuarioAppServices.AgregarUsuario(usuario);
            if (respuesta == null)
            {
                return Ok("Exito");
            }
            else
            {
                return BadRequest(respuesta);
            }
        }

        [HttpPut("{idUsuario}")]

        public async Task<ActionResult> putUsuario(int idUsuario, Usuario usuario)
        {

            if (idUsuario == usuario.idUsuario)
            {
                _db.Entry(usuario).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return Ok();
            }

            return BadRequest();

        }

        [HttpDelete("{idUsuario}")]
        public async Task<ActionResult> deleteUsuario(int idUsuario)
        {
            var usuario = await _db.Usuario.FindAsync(idUsuario);
            if (usuario == null)
            {
                return NotFound();
            }
            _db.Usuario.Remove(usuario);
            await _db.SaveChangesAsync();
            return Ok();
        }

    }
}