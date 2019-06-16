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
    public class RecetadetalleController : ControllerBase
    {
        private readonly VinosDBContext _context;

        public RecetadetalleController(VinosDBContext context)
        {
            _context = context;
        }

        // GET: api/Recetadetalle
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recetadetalle>>> GetRecetadetalle()
        {
            return await _context.Recetadetalle.ToListAsync();
        }

        // GET: api/Recetadetalle/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Recetadetalle>> GetRecetadetalle(int id)
        {
            var recetadetalle = await _context.Recetadetalle.FindAsync(id);

            if (recetadetalle == null)
            {
                return NotFound();
            }

            return recetadetalle;
        }

        // PUT: api/Recetadetalle/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecetadetalle(int id, Recetadetalle recetadetalle)
        {
            if (id != recetadetalle.Idrecetadetalle)
            {
                return BadRequest();
            }

            _context.Entry(recetadetalle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecetadetalleExists(id))
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

        // POST: api/Recetadetalle
        [HttpPost]
        public async Task<ActionResult<Recetadetalle>> PostRecetadetalle(Recetadetalle recetadetalle)
        {
            _context.Recetadetalle.Add(recetadetalle);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RecetadetalleExists(recetadetalle.Idrecetadetalle))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRecetadetalle", new { id = recetadetalle.Idrecetadetalle }, recetadetalle);
        }

        // DELETE: api/Recetadetalle/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Recetadetalle>> DeleteRecetadetalle(int id)
        {
            var recetadetalle = await _context.Recetadetalle.FindAsync(id);
            if (recetadetalle == null)
            {
                return NotFound();
            }

            _context.Recetadetalle.Remove(recetadetalle);
            await _context.SaveChangesAsync();

            return recetadetalle;
        }

        private bool RecetadetalleExists(int id)
        {
            return _context.Recetadetalle.Any(e => e.Idrecetadetalle == id);
        }
    }
}
