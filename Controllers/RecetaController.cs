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
    public class RecetaController : ControllerBase
    {
        private readonly VinosDBContext _context;

        public RecetaController(VinosDBContext context)
        {
            _context = context;
        }

        // GET: api/Receta
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Receta>>> GetReceta()
        {
            return await _context.Receta.ToListAsync();
        }

        // GET: api/Receta/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Receta>> GetReceta(int id)
        {
            var receta = await _context.Receta.FindAsync(id);

            if (receta == null)
            {
                return NotFound();
            }

            return receta;
        }

        // PUT: api/Receta/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReceta(int id, Receta receta)
        {
            if (id != receta.Idreceta)
            {
                return BadRequest();
            }

            _context.Entry(receta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecetaExists(id))
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

        // POST: api/Receta
        [HttpPost]
        public async Task<ActionResult<Receta>> PostReceta(Receta receta)
        {
            _context.Receta.Add(receta);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RecetaExists(receta.Idreceta))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetReceta", new { id = receta.Idreceta }, receta);
        }

        // DELETE: api/Receta/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Receta>> DeleteReceta(int id)
        {
            var receta = await _context.Receta.FindAsync(id);
            if (receta == null)
            {
                return NotFound();
            }

            _context.Receta.Remove(receta);
            await _context.SaveChangesAsync();

            return receta;
        }

        private bool RecetaExists(int id)
        {
            return _context.Receta.Any(e => e.Idreceta == id);
        }
    }
}
