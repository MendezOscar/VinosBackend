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
    public class RecetadtlController : ControllerBase
    {
        private readonly VinosDBContext _context;

        public RecetadtlController(VinosDBContext context)
        {
            _context = context;
        }

        // GET: api/Recetadtl
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recetadtl>>> GetRecetadtl()
        {
            return await _context.Recetadtl.ToListAsync();
        }

        // GET: api/Recetadtl/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Recetadtl>> GetRecetadtl(int id)
        {
            var recetadtl = await _context.Recetadtl.FindAsync(id);

            if (recetadtl == null)
            {
                return NotFound();
            }

            return recetadtl;
        }

        // PUT: api/Recetadtl/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecetadtl(int id, Recetadtl recetadtl)
        {
            if (id != recetadtl.Idrecetadetalle)
            {
                return BadRequest();
            }

            _context.Entry(recetadtl).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecetadtlExists(id))
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

        // POST: api/Recetadtl
        [HttpPost]
        public async Task<ActionResult<Recetadtl>> PostRecetadtl(Recetadtl recetadtl)
        {
            _context.Recetadtl.Add(recetadtl);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RecetadtlExists(recetadtl.Idrecetadetalle))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRecetadtl", new { id = recetadtl.Idrecetadetalle }, recetadtl);
        }

        // DELETE: api/Recetadtl/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Recetadtl>> DeleteRecetadtl(int id)
        {
            var recetadtl = await _context.Recetadtl.FindAsync(id);
            if (recetadtl == null)
            {
                return NotFound();
            }

            _context.Recetadtl.Remove(recetadtl);
            await _context.SaveChangesAsync();

            return recetadtl;
        }

        private bool RecetadtlExists(int id)
        {
            return _context.Recetadtl.Any(e => e.Idrecetadetalle == id);
        }
    }
}
