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
    public class ExistenciasController : ControllerBase
    {
        private readonly VinosDBContext _context;

        public ExistenciasController(VinosDBContext context)
        {
            _context = context;
        }

        // GET: api/Existencias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Existencias>>> GetExistencias()
        {
            return await _context.Existencias.ToListAsync();
        }

        // GET: api/Existencias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Existencias>> GetExistencias(int id)
        {
            var existencias = await _context.Existencias.FindAsync(id);

            if (existencias == null)
            {
                return NotFound();
            }

            return existencias;
        }

        // PUT: api/Existencias/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExistencias(int id, Existencias existencias)
        {
            if (id != existencias.Idexistencia)
            {
                return BadRequest();
            }

            _context.Entry(existencias).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExistenciasExists(id))
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

        // POST: api/Existencias
        [HttpPost]
        public async Task<ActionResult<Existencias>> PostExistencias(Existencias existencias)
        {
            _context.Existencias.Add(existencias);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ExistenciasExists(existencias.Idexistencia))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetExistencias", new { id = existencias.Idexistencia }, existencias);
        }

        // DELETE: api/Existencias/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Existencias>> DeleteExistencias(int id)
        {
            var existencias = await _context.Existencias.FindAsync(id);
            if (existencias == null)
            {
                return NotFound();
            }

            _context.Existencias.Remove(existencias);
            await _context.SaveChangesAsync();

            return existencias;
        }

        private bool ExistenciasExists(int id)
        {
            return _context.Existencias.Any(e => e.Idexistencia == id);
        }
    }
}
