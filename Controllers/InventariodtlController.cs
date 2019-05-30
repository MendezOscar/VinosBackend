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
    public class InventariodtlController : ControllerBase
    {
        private readonly VinosDBContext _context;

        public InventariodtlController(VinosDBContext context)
        {
            _context = context;
        }

        // GET: api/Inventariodtl
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inventariodtl>>> GetInventariodtl()
        {
            return await _context.Inventariodtl.ToListAsync();
        }

        // GET: api/Inventariodtl/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Inventariodtl>> GetInventariodtl(int id)
        {
            var inventariodtl = await _context.Inventariodtl.FindAsync(id);

            if (inventariodtl == null)
            {
                return NotFound();
            }

            return inventariodtl;
        }

        // PUT: api/Inventariodtl/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInventariodtl(int id, Inventariodtl inventariodtl)
        {
            if (id != inventariodtl.Idinventariodetalle)
            {
                return BadRequest();
            }

            _context.Entry(inventariodtl).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventariodtlExists(id))
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

        // POST: api/Inventariodtl
        [HttpPost]
        public async Task<ActionResult<Inventariodtl>> PostInventariodtl(Inventariodtl inventariodtl)
        {
            _context.Inventariodtl.Add(inventariodtl);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (InventariodtlExists(inventariodtl.Idinventariodetalle))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetInventariodtl", new { id = inventariodtl.Idinventariodetalle }, inventariodtl);
        }

        // DELETE: api/Inventariodtl/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Inventariodtl>> DeleteInventariodtl(int id)
        {
            var inventariodtl = await _context.Inventariodtl.FindAsync(id);
            if (inventariodtl == null)
            {
                return NotFound();
            }

            _context.Inventariodtl.Remove(inventariodtl);
            await _context.SaveChangesAsync();

            return inventariodtl;
        }

        private bool InventariodtlExists(int id)
        {
            return _context.Inventariodtl.Any(e => e.Idinventariodetalle == id);
        }
    }
}
