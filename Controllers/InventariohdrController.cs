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
    public class InventariohdrController : ControllerBase
    {
        private readonly VinosDBContext _context;

        public InventariohdrController(VinosDBContext context)
        {
            _context = context;
        }

        // GET: api/Inventariohdr
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inventariohdr>>> GetInventariohdr()
        {
            return await _context.Inventariohdr.ToListAsync();
        }

        // GET: api/Inventariohdr/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Inventariohdr>> GetInventariohdr(int id)
        {
            var inventariohdr = await _context.Inventariohdr.FindAsync(id);

            if (inventariohdr == null)
            {
                return NotFound();
            }

            return inventariohdr;
        }

        // PUT: api/Inventariohdr/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInventariohdr(int id, Inventariohdr inventariohdr)
        {
            if (id != inventariohdr.Idinventario)
            {
                return BadRequest();
            }

            _context.Entry(inventariohdr).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventariohdrExists(id))
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

        // POST: api/Inventariohdr
        [HttpPost]
        public async Task<ActionResult<Inventariohdr>> PostInventariohdr(Inventariohdr inventariohdr)
        {
            _context.Inventariohdr.Add(inventariohdr);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (InventariohdrExists(inventariohdr.Idinventario))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetInventariohdr", new { id = inventariohdr.Idinventario }, inventariohdr);
        }

        // DELETE: api/Inventariohdr/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Inventariohdr>> DeleteInventariohdr(int id)
        {
            var inventariohdr = await _context.Inventariohdr.FindAsync(id);
            if (inventariohdr == null)
            {
                return NotFound();
            }

            _context.Inventariohdr.Remove(inventariohdr);
            await _context.SaveChangesAsync();

            return inventariohdr;
        }

        private bool InventariohdrExists(int id)
        {
            return _context.Inventariohdr.Any(e => e.Idinventario == id);
        }
    }
}
