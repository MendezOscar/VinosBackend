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
    public class RecetahdrController : ControllerBase
    {
        private readonly VinosDBContext _context;

        public RecetahdrController(VinosDBContext context)
        {
            _context = context;
        }

        // GET: api/Recetahdr
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recetahdr>>> GetRecetahdr()
        {
            return await _context.Recetahdr.ToListAsync();
        }

        // GET: api/Recetahdr/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Recetahdr>> GetRecetahdr(int id)
        {
            var recetahdr = await _context.Recetahdr.FindAsync(id);

            if (recetahdr == null)
            {
                return NotFound();
            }

            return recetahdr;
        }

        // PUT: api/Recetahdr/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecetahdr(int id, Recetahdr recetahdr)
        {
            if (id != recetahdr.Idreceta)
            {
                return BadRequest();
            }

            _context.Entry(recetahdr).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecetahdrExists(id))
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

        // POST: api/Recetahdr
        [HttpPost]
        public async Task<ActionResult<Recetahdr>> PostRecetahdr(Recetahdr recetahdr)
        {
            _context.Recetahdr.Add(recetahdr);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RecetahdrExists(recetahdr.Idreceta))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRecetahdr", new { id = recetahdr.Idreceta }, recetahdr);
        }

        // DELETE: api/Recetahdr/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Recetahdr>> DeleteRecetahdr(int id)
        {
            var recetahdr = await _context.Recetahdr.FindAsync(id);
            if (recetahdr == null)
            {
                return NotFound();
            }

            _context.Recetahdr.Remove(recetahdr);
            await _context.SaveChangesAsync();

            return recetahdr;
        }

        private bool RecetahdrExists(int id)
        {
            return _context.Recetahdr.Any(e => e.Idreceta == id);
        }
    }
}
