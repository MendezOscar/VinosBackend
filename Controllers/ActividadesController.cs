using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VinosBackend.Models;

namespace VinosBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActividadesController : ControllerBase
    {
        private readonly VinosDBContext _context;

        public ActividadesController(VinosDBContext context)
        {
            _context = context;
        }

        // GET: api/Actividades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Actividades>>> GetActividades()
        {
            return await _context.Actividades.ToListAsync();
        }

        // GET: api/Actividades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Actividades>> GetActividades(int id)
        {
            var actividades = await _context.Actividades.FindAsync(id);

            if (actividades == null)
            {
                return NotFound();
            }

            return actividades;
        }

        // PUT: api/Actividades/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActividades(int id, Actividades actividades)
        {
            if (id != actividades.Idactividad)
            {
                return BadRequest();
            }

            _context.Entry(actividades).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActividadesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Actividades
        [HttpPost]
        public async Task<ActionResult<Actividades>> PostActividades(Actividades actividades)
        {
            _context.Actividades.Add(actividades);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ActividadesExists(actividades.Idactividad))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetActividades", new { id = actividades.Idactividad }, actividades);
        }

        // DELETE: api/Actividades/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Actividades>> DeleteActividades(int id)
        {
            var actividades = await _context.Actividades.FindAsync(id);
            if (actividades == null)
            {
                return NotFound();
            }

            _context.Actividades.Remove(actividades);
            await _context.SaveChangesAsync();

            return actividades;
        }

        private bool ActividadesExists(int id)
        {
            return _context.Actividades.Any(e => e.Idactividad == id);
        }
    }
}
