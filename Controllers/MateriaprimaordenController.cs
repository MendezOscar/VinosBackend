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
    public class MateriaprimaordenController : ControllerBase
    {
        private readonly VinosDBContext _context;

        public MateriaprimaordenController(VinosDBContext context)
        {
            _context = context;
        }

        // GET: api/Materiaprimaorden
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Materiaprimaoden>>> GetMateriaprimaoden()
        {
            return await _context.Materiaprimaoden.ToListAsync();
        }

        // GET: api/Materiaprimaorden/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Materiaprimaoden>> GetMateriaprimaoden(int id)
        {
            var materiaprimaoden = await _context.Materiaprimaoden.FindAsync(id);

            if (materiaprimaoden == null)
            {
                return NotFound();
            }

            return materiaprimaoden;
        }

        // PUT: api/Materiaprimaorden/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMateriaprimaoden(int id, Materiaprimaoden materiaprimaoden)
        {
            if (id != materiaprimaoden.Idmateriaprimaorden)
            {
                return BadRequest();
            }

            _context.Entry(materiaprimaoden).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MateriaprimaodenExists(id))
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

        // POST: api/Materiaprimaorden
        [HttpPost]
        public async Task<ActionResult<Materiaprimaoden>> PostMateriaprimaoden(Materiaprimaoden materiaprimaoden)
        {
            _context.Materiaprimaoden.Add(materiaprimaoden);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MateriaprimaodenExists(materiaprimaoden.Idmateriaprimaorden))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMateriaprimaoden", new { id = materiaprimaoden.Idmateriaprimaorden }, materiaprimaoden);
        }

        // DELETE: api/Materiaprimaorden/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Materiaprimaoden>> DeleteMateriaprimaoden(int id)
        {
            var materiaprimaoden = await _context.Materiaprimaoden.FindAsync(id);
            if (materiaprimaoden == null)
            {
                return NotFound();
            }

            _context.Materiaprimaoden.Remove(materiaprimaoden);
            await _context.SaveChangesAsync();

            return materiaprimaoden;
        }

        private bool MateriaprimaodenExists(int id)
        {
            return _context.Materiaprimaoden.Any(e => e.Idmateriaprimaorden == id);
        }
    }
}
