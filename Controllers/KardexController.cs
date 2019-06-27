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
    public class KardexController : ControllerBase
    {
        private readonly VinosDBContext _context;

        public KardexController(VinosDBContext context)
        {
            _context = context;
        }

        // GET: api/Kardex
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kardex>>> GetKardex()
        {
            return await _context.Kardex.ToListAsync();
        }

        // GET: api/Kardex/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kardex>> GetKardex(int id)
        {
            var kardex = await _context.Kardex.FindAsync(id);

            if (kardex == null)
            {
                return NotFound();
            }

            return kardex;
        }

        // PUT: api/Kardex/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKardex(int id, Kardex kardex)
        {
            if (id != kardex.Idkardex)
            {
                return BadRequest();
            }

            _context.Entry(kardex).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KardexExists(id))
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

        // POST: api/Kardex
        [HttpPost]
        public async Task<ActionResult<Kardex>> PostKardex(Kardex kardex)
        {
            _context.Kardex.Add(kardex);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (KardexExists(kardex.Idkardex))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetKardex", new { id = kardex.Idkardex }, kardex);
        }

        // DELETE: api/Kardex/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Kardex>> DeleteKardex(int id)
        {
            var kardex = await _context.Kardex.FindAsync(id);
            if (kardex == null)
            {
                return NotFound();
            }

            _context.Kardex.Remove(kardex);
            await _context.SaveChangesAsync();

            return kardex;
        }

        private bool KardexExists(int id)
        {
            return _context.Kardex.Any(e => e.Idkardex == id);
        }
    }
}
